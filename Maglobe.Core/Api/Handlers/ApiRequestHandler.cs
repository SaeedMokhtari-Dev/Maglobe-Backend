using System;
using System.Reflection;
using System.Threading.Tasks;
using Maglobe.Core.Api.Exceptions;
using Maglobe.Core.Api.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ActionResult = Maglobe.Core.Api.Models.ActionResult;

namespace Maglobe.Core.Api.Handlers
{
    public abstract class ApiRequestHandler<T>: IApiRequestHandler<T>
    {
        // ReSharper disable once StaticMemberInGenericType
        protected static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        static ApiRequestHandler()
        {
            LogManager.AddHiddenAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<IActionResult> Handle(T request)
        {
            try
            {
                var result = await Execute(request);

                return ApiResponse.Result(result);
            }
            catch (ApiException ex)
            {
                Logger.Error(ex);
                return ApiResponse.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ApiResponse.Error();
            }
        }

        protected abstract Task<ActionResult> Execute(T request);
    }
}

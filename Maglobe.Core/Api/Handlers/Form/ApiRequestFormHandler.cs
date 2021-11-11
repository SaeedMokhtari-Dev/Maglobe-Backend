using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Maglobe.Core.Api.Exceptions;
using Maglobe.Core.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ActionResult = Maglobe.Core.Api.Models.ActionResult;

namespace Maglobe.Core.Api.Handlers.Form
{
    public abstract class ApiRequestFormHandler<T>: IApiRequestFormHandler<T>
    {
        // ReSharper disable once StaticMemberInGenericType
        protected static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        static ApiRequestFormHandler()
        {
            LogManager.AddHiddenAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<IActionResult> Handle(T request, List<IFormFile> files)
        {
            try
            {
                var result = await Execute(request, files);

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

        protected abstract Task<ActionResult> Execute(T request, List<IFormFile> files);
    }
}

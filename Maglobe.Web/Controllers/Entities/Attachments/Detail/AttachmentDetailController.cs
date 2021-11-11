using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Attachments.Detail
{
    [Route(Endpoints.ApiAttachmentDetail)]
    [ApiExplorerSettings(GroupName = "Attachment")]
    [Authorize]
    public class AttachmentDetailController : ApiController<AttachmentDetailRequest>
    {
        public AttachmentDetailController(IApiRequestHandler<AttachmentDetailRequest> handler, IValidator<AttachmentDetailRequest> validator) : base(handler, validator)
        {
        }
        /*private readonly MaglobeContext _context;
        public AttachmentDetailController(MaglobeContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [ResponseCache(Duration = 300)]
        public async Task<ActionResult> Get([FromQuery] long attachmentId)
        {
            Attachment attachment = await _context.Attachments
                .FindAsync(attachmentId);

            if (attachment == null)
            {
                return Problem(ApiMessages.ResourceNotFound);
            }

            //AttachmentDetailResponse response = _mapper.Map<AttachmentDetailResponse>(election);
            
            return Ok(String.Join("", attachment.Image.Select(Convert.ToChar)));
        }*/
    }
}

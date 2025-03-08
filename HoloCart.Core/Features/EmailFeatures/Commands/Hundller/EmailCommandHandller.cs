using HoloCart.Core.Bases;
using HoloCart.Core.Features.EmailFeatures.Commands.Requests;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.EmailFeatures.Commands.Hundller
{
    public class EmailCommandHandller : ResponseHandller,
        IRequestHandler<SendEmailRequest, Response<string>>
    {
        #region Fields
        private readonly IEmailService _emailService;

        #endregion
        #region Constructors
        public EmailCommandHandller(IEmailService emailService)
        {
            this._emailService = emailService;
        }
        #endregion
        #region Handle Functions

        #endregion


        public async Task<Response<string>> Handle(SendEmailRequest request, CancellationToken cancellationToken)
        {
            var response = await _emailService.SendEmailAsync(request.Email, request.Message, "Confirm Email");
            if (response == "Success")
                return Success<string>("Email send Successfully");
            else
                return BadRequest<string>("failed to send Email");
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using user_handler.Model;

namespace user_handler.UseCase.User.Command.Post
{
    public class Handler : IRequestHandler<Command, Dto>
    {
        private readonly Context konteks;

        public Handler(Context context)
        {
            konteks = context;
        }

        public async Task<Dto> Handle(Command request, CancellationToken cancellationToken)
        {
            var userdata = new user_model();
            konteks.user.Add(userdata);
            await konteks.SaveChangesAsync(cancellationToken);
            return new Dto
            {
                message = "user posted",
                success = true
            };
        }
    }
}

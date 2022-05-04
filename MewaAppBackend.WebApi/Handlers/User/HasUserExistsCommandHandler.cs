using MediatR;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class HasUserExistsCommandHandler : IRequestHandler<HasUserExistsCommand, bool>
    {
        private readonly Context _context;
        public HasUserExistsCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<bool> Handle(HasUserExistsCommand request, CancellationToken cancellationToken)
        {
            var result = _context.Users.Any(u => u.UserName.ToLower() == request.UserName.ToLower());
            return result;
        }
    }
}

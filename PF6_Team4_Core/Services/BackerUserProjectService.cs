using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Services
{
    class BackerUserProjectService : IBackerUserProjectService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<BackerUserProjectService> _logger;

        public BackerUserProjectService(IApplicationDbContext context, ILogger<BackerUserProjectService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Result<BackerUserProject>> DonateAmount(BackerUserProject donateamount)
        {
            if (donateamount.AmountDonated <= 0)
            {
                return new Result<BackerUserProject>(ErrorCode.BadRequest, "Amount can't be less than zero.");
            }

            var newDonation = new BackerUserProject
            {
                ProjectId = donateamount.ProjectId,
                UserId = donateamount.UserId,
                AmountDonated = donateamount.AmountDonated
            };

            await _context.BackerUserProjects.AddAsync(newDonation);
            await _context.SaveChangesAsync();

            return new Result<BackerUserProject>
            {
                Data = newDonation
            };

        }
    }
}

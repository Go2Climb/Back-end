﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Repositories;
using Go2Climb.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Go2Climb.API.Persistence.Repositories
{
    public class AgencyReviewsRepository : BaseRepository, IAgencyReviewRepository
    {
        public AgencyReviewsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AgencyReview>> ListAsync()
        {
            return await _context.AgencyReviews.ToListAsync();
        }
    }
}
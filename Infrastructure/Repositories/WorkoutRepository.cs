using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly AppDbContext _context;

        public WorkoutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Workout workout, CancellationToken cancellationToken = default)
        {
            await _context.Workouts.AddAsync(workout, cancellationToken);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<List<Workout>> GetByUserAndMonthAsync(int userId, int year, int month,
            CancellationToken cancellationToken = default)
        {
            return await _context.Workouts
                .Where(w => w.UserId == userId && w.WorkoutDateTime.Year == year && w.WorkoutDateTime.Month == month)
                .OrderBy(w => w.WorkoutDateTime)
                .ToListAsync(cancellationToken);
        }
    }
}
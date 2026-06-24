using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWorkoutRepository
    {
        Task AddAsync(Workout workout, CancellationToken cancellationToken = default);
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<List<Workout>> GetByUserAndMonthAsync(int userId, int year, int month,
            CancellationToken cancellationToken = default);
    }
}
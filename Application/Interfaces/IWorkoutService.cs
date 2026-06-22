using Application.DTOs.Workout;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWorkoutService
    {
        Task<Result<WorkoutResponseDto>> AddAsync(CreateWorkoutDto dto, int userId, CancellationToken cancellationToken = default);
    }
}

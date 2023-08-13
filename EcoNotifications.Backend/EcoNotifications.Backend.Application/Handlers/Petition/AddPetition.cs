using EcoNotifications.Backend.Application.Common.DTO.Requests;
using EcoNotifications.Backend.Application.Common.DTO.Responses;
using EcoNotifications.Backend.DataAccess;
using EcoNotifications.Backend.DataAccess.Enums;
using EcoNotifications.Backend.DataAccess.Services.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcoNotifications.Backend.Application.Handlers.Petition;

public record AddPetition(PetitionFormRequest PetitionFormRequest) : IRequest<PetitionResponse>;

public class AddPetitionHandler : IRequestHandler<AddPetition, PetitionResponse>
{
    private readonly EcoNotificationsDbContext _context;
    private readonly IHashService _hashService;
    
    public AddPetitionHandler(EcoNotificationsDbContext context, IHashService hashService)
    {
        _context = context;
        _hashService = hashService;
    }
    
    public async Task<PetitionResponse> Handle(AddPetition request, CancellationToken cancellationToken)
    {
        var entityPetition = request.PetitionFormRequest.Adapt<DataAccess.Models.Petition>();
        entityPetition.Status = StatusPetition.New;
        
        var savedPetition = await _context.Petitions.AddAsync(entityPetition, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        _context.Entry(entityPetition).State = EntityState.Detached;

        return savedPetition.Adapt<PetitionResponse>();
    }
}
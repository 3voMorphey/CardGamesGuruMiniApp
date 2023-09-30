﻿using MediatR;
using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using Services.CardGamesGuruMiniApp.Services.TotService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.GameHandler;

public class CreateCardQuery : IRequest<TotCard>
{
    public string FirstQuestion { get; set; }
    public string SecondQuestion { get; set; }
}

public class CreateCardHandler : IRequestHandler<CreateCardQuery,TotCard>
{

    private readonly ITotService _totService;

    public CreateCardHandler(ITotService totService)
    {
        _totService = totService;
    }

    public async Task<TotCard> Handle(CreateCardQuery request, CancellationToken cancellationToken)
    {
        var card = new TotCard()
        {
            FirstQuestion = request.FirstQuestion,
            SecondQuestion = request.SecondQuestion,
            CardId = Guid.NewGuid(),
            CreatedDate = DateTime.UtcNow
        };

        await _totService.CreateTotCardAsync(card);

        return card;

    }
}
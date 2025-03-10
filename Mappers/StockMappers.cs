using System;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers;

public static class StockMappers 
{
    public static StockDto ToStockDto(this Stock stockModel){
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            Lastdev = stockModel.Lastdev,
            Industry = stockModel.Industry,
            Marketcap = stockModel.Marketcap,
            Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList(),
        };
    }

    public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto)
    {

        return new Stock
        {
            Symbol= stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Purchase = stockDto.Purchase,
            Lastdev = stockDto.Lastdev,
            Industry = stockDto.Industry,
            Marketcap  = stockDto.Marketcap,
        };

    } 

}

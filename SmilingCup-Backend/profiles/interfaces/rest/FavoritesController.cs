using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SmilingCup_Backend.profiles.domain.model.queries;
using SmilingCup_Backend.profiles.domain.services;
using SmilingCup_Backend.profiles.interfaces.rest.resources;
using SmilingCup_Backend.profiles.interfaces.rest.transform;
using Swashbuckle.AspNetCore.Annotations;

namespace SmilingCup_Backend.profiles.interfaces.rest;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Favorite Endpoints.")]
public class FavoritesController(
    IFavoriteCommandService favoriteCommandService,
    IFavoriteQueryService favoriteQueryService)
    : ControllerBase
{
     [HttpGet("{favoriteId:int}")]
    [SwaggerOperation("Get Favorite by Id", "Get a favorite by its unique identifier.", OperationId = "GetFavoriteById")]
    [SwaggerResponse(200, "The favorite was found and returned.", typeof(FavoriteResource))]
    [SwaggerResponse(404, "The favorite was not found.")]
    public async Task<IActionResult> GetFavoriteById(int favoriteId)
    {
        var getFavoriteByIdQuery = new GetFavoriteByIdQuery(favoriteId);
        var favorite = await favoriteQueryService.Handle(getFavoriteByIdQuery);
        if (favorite is null) return NotFound();
        var favoriteResource = FavoriteResourceFromEntityAssembler.ToResourceFromEntity(favorite);
        return Ok(favoriteResource);
    }

    [HttpPost]
    [SwaggerOperation("Create Favorite", "Create a new favorite.", OperationId = "CreateFavorite")]
    [SwaggerResponse(201, "The favorite was created.", typeof(FavoriteResource))]
    [SwaggerResponse(400, "The favorite was not created.")]
    public async Task<IActionResult> CreateFavorite(CreateFavoriteResource resource)
    {
        var createFavoriteCommand = CreateFavoriteCommandFromResourceAssembler.ToCommandFromResource(resource);
        var favorite = await favoriteCommandService.Handle(createFavoriteCommand);
        if (favorite is null) return BadRequest();
        var favoriteResource = FavoriteResourceFromEntityAssembler.ToResourceFromEntity(favorite);
        return CreatedAtAction(nameof(GetFavoriteById), new { favoriteId = favorite.id }, favoriteResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Favorites", "Get all favorites.", OperationId = "GetAllFavorites")]
    [SwaggerResponse(200, "The favorites were found and returned.", typeof(IEnumerable<FavoriteResource>))]
    [SwaggerResponse(404, "The favorites were not found.")]
    public async Task<IActionResult> GetAllFavorites()
    {
        var getAllFavoritesQuery = new GetAllFavoritesQuery();
        var favorites = await favoriteQueryService.Handle(getAllFavoritesQuery);
        var favoriteResources = favorites.Select(FavoriteResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(favoriteResources);
    }
    
}
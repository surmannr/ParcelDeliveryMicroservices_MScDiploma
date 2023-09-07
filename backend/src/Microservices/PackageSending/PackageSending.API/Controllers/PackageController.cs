﻿using AutoMapper;
using Common.Dto;
using Common.Entity.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PackageSending.BL.Features._Package.Commands;
using PackageSending.BL.Features._Package.Queries;

namespace PackageSending.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PackageController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PackageDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PackageDto>>> GetPackages([FromQuery] PackageFilter parameter)
        {
            var packages = await _mediator.Send(_mapper.Map<GetAllPackages.Query>(parameter));
            return Ok(packages);
        }

        [HttpGet("{id}", Name = "GetPackageById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(PackageDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<PackageDto>> GetPackageById(string id)
        {
            var package = await _mediator.Send(new GetPackageById.Query()
            {
                Id = id
            });
            return Ok(package);
        }

        [HttpGet("shipreq-{id}")]
        [ProducesResponseType(typeof(IEnumerable<PackageDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PackageDto>>> GetPackagesByShipRequestId(string id, [FromQuery] PackageFilter parameter)
        {
            var query = _mapper.Map<GetAllPackagesByShipReqId.Query>(parameter);
            query.ShipReqId = id;
            var packages = await _mediator.Send(query);
            return Ok(packages);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PackageDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<PackageDto>> CreatePackage([FromBody] PackageDto package)
        {
            var id = await _mediator.Send(new AddNewPackage.Command()
            {
                NewPackage = package
            });
            package.Id = id;
            return CreatedAtRoute("GetPackageById", new { id = id }, package);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PackageDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> UpdatePackage([FromBody] PackageDto package)
        {
            var result = await _mediator.Send(new EditPackage.Command()
            {
                ModifiedPackage = package
            });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PackageDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> DeletePackage(string id)
        {
            var result = await _mediator.Send(new DeletePackage.Command()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}

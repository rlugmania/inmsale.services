using InmSale.Infrastructure.Data;
using InmSale.Models.Commons;
using NetTopologySuite.Geometries;

namespace InmSale.Models;

[MongoCollection("projects")]
public class Project : EntityModel
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public Geometry? GeoFence { get; set; }

    public Point? Location { get; set; }
}
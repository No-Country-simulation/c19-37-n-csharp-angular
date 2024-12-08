# Define el nombre del proyecto
$projectName = "bankito"

try {
    # Crear el proyecto base
    dotnet new webapi -n $projectName
    if ($LASTEXITCODE -ne 0) { throw "Error al crear el proyecto base" }
    cd $projectName

    # Crear carpetas
    New-Item -ItemType Directory -Path "Models"
    New-Item -ItemType Directory -Path "DTOs"
    New-Item -ItemType Directory -Path "Repositories"
    New-Item -ItemType Directory -Path "Services"
    New-Item -ItemType Directory -Path "Controllers"

    # Función para crear archivos de modelo
    function Create-ModelFile {
        param (
            [string]$fileName,
            [string]$content
        )
        Set-Content -Path "Models\$fileName.cs" -Value $content
    }

    # Función para crear archivos DTO
    function Create-DtoFile {
        param (
            [string]$fileName,
            [string]$content
        )
        Set-Content -Path "DTOs\$fileName.cs" -Value $content
    }

    # Función para crear interfaces y clases de repository
    function Create-RepositoryFiles {
        param (
            [string]$entityName
        )
        $interfaceContent = @"
using System.Collections.Generic;
using $projectName.Models;

namespace $projectName.Repositories
{
    public interface I${entityName}Repository
    {
        IEnumerable<$entityName> GetAll();
        $entityName GetById(int id);
        void Add($entityName $($entityName.ToLower()));
        void Update($entityName $($entityName.ToLower()));
        void Delete(int id);
    }
}
"@
        Set-Content -Path "Repositories\I${entityName}Repository.cs" -Value $interfaceContent

        $classContent = @"
using System.Collections.Generic;
using System.Linq;
using $projectName.Models;

namespace $projectName.Repositories
{
    public class ${entityName}Repository : I${entityName}Repository
    {
        private readonly List<$entityName> _${($entityName.ToLower())}s = new List<$entityName>();

        public IEnumerable<$entityName> GetAll() => _${($entityName.ToLower())}s;

        public $entityName GetById(int id) => _${($entityName.ToLower())}s.FirstOrDefault(p => p.Id == id);

        public void Add($entityName $($entityName.ToLower())) => _${($entityName.ToLower())}s.Add($($entityName.ToLower()));

        public void Update($entityName $($entityName.ToLower()))
        {
            var index = _${($entityName.ToLower())}s.FindIndex(p => p.Id == $($entityName.ToLower()).Id);
            if (index >= 0) _${($entityName.ToLower())}s[index] = $($entityName.ToLower());
        }

        public void Delete(int id)
        {
            var $($entityName.ToLower()) = _${($entityName.ToLower())}s.FirstOrDefault(p => p.Id == id);
            if ($($entityName.ToLower()) != null) _${($entityName.ToLower())}s.Remove($($entityName.ToLower()));
        }
    }
}
"@
        Set-Content -Path "Repositories\${entityName}Repository.cs" -Value $classContent
    }

    # Función para crear interfaces y clases de service
    function Create-ServiceFiles {
        param (
            [string]$entityName
        )
        $interfaceContent = @"
using System.Collections.Generic;
using $projectName.DTOs;

namespace $projectName.Services
{
    public interface I${entityName}Service
    {
        IEnumerable<${entityName}Dto> GetAll();
        ${entityName}Dto GetById(int id);
        void Add(${entityName}Dto $($entityName.ToLower())Dto);
        void Update(${entityName}Dto $($entityName.ToLower())Dto);
        void Delete(int id);
    }
}
"@
        Set-Content -Path "Services\I${entityName}Service.cs" -Value $interfaceContent

        $classContent = @"
using System.Collections.Generic;
using System.Linq;
using $projectName.DTOs;
using $projectName.Models;
using $projectName.Repositories;

namespace $projectName.Services
{
    public class ${entityName}Service : I${entityName}Service
    {
        private readonly I${entityName}Repository _${($entityName.ToLower())}Repository;

        public ${entityName}Service(I${entityName}Repository $($entityName.ToLower())Repository)
        {
            _${($entityName.ToLower())}Repository = $($entityName.ToLower())Repository;
        }

        public IEnumerable<${entityName}Dto> GetAll()
        {
            return _${($entityName.ToLower())}Repository.GetAll().Select(p => new ${entityName}Dto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public ${entityName}Dto GetById(int id)
        {
            var $($entityName.ToLower()) = _${($entityName.ToLower())}Repository.GetById(id);
            if ($($entityName.ToLower()) == null) return null;

            return new ${entityName}Dto
            {
                Id = $($entityName.ToLower()).Id,
                // Add other properties here
            };
        }

        public void Add(${entityName}Dto $($entityName.ToLower())Dto)
        {
            var $($entityName.ToLower()) = new $entityName
            {
                Id = $($entityName.ToLower())Dto.Id,
                // Add other properties here
            };
            _${($entityName.ToLower())}Repository.Add($($entityName.ToLower()));
        }

        public void Update(${entityName}Dto $($entityName.ToLower())Dto)
        {
            var $($entityName.ToLower()) = new $entityName
            {
                Id = $($entityName.ToLower())Dto.Id,
                // Add other properties here
            };
            _${($entityName.ToLower())}Repository.Update($($entityName.ToLower()));
        }

        public void Delete(int id) => _${($entityName.ToLower())}Repository.Delete(id);
    }
}
"@
        Set-Content -Path "Services\${entityName}Service.cs" -Value $classContent
    }

    # Función para crear archivos de controlador
    function Create-ControllerFile {
        param (
            [string]$entityName
        )
        $controllerContent = @"
using Microsoft.AspNetCore.Mvc;
using $projectName.DTOs;
using $projectName.Services;

namespace $projectName.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ${entityName}Controller : ControllerBase
{
    private readonly I${entityName}Service _${($entityName.ToLower())}Service;

    public ${entityName}Controller(I${entityName}Service $($entityName.ToLower())Service)
    {
        _${($entityName.ToLower())}Service = $($entityName.ToLower())Service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<${entityName}Dto>> GetAll()
    {
        return Ok(_${($entityName.ToLower())}Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<${entityName}Dto> GetById(int id)
    {
        var $($entityName.ToLower()) = _${($entityName.ToLower())}Service.GetById(id);
        if ($($entityName.ToLower()) == null)
        {
            return NotFound();
        }
        return Ok($($entityName.ToLower()));
    }

    [HttpPost]
    public ActionResult Add(${entityName}Dto $($entityName.ToLower())Dto)
    {
        _${($entityName.ToLower())}Service.Add($($entityName.ToLower())Dto);
        return CreatedAtAction(nameof(GetById), new { id = $($entityName.ToLower())Dto.Id }, $($entityName.ToLower())Dto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, ${entityName}Dto $($entityName.ToLower())Dto)
    {
        if (id != $($entityName.ToLower())Dto.Id)
        {
            return BadRequest();
        }
        _${($entityName.ToLower())}Service.Update($($entityName.ToLower())Dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _${($entityName.ToLower())}Service.Delete(id);
        return NoContent();
    }
}
"@
        Set-Content -Path "Controllers\${entityName}Controller.cs" -Value $controllerContent
    }

    # Crear archivos de modelo
    $models = @(
        "Role",
        "Country",
        "Card",
        "StatusCard",
        "User",
        "UserRole",
        "ManualBan",
        "Ban",
        "BankTransfer",
        "BankTransferStatus",
        "Bill",
        "BillStatus",
        "BillType",
        "Payment"
    )

    foreach ($model in $models) {
        Create-ModelFile $model @"
namespace $projectName.Models
{
    public class $model
    {
        public int Id { get; set; }
        // Add other properties here
    }
}
"@
    }

    # Crear archivos DTO
    foreach ($model in $models) {
        Create-DtoFile "${model}Dto" @"
namespace $projectName.DTOs
{
    public class ${model}Dto
    {
        public int Id { get; set; }
        // Add other properties here
    }
}
"@
    }

    # Crear interfaces y clases de repository
    foreach ($model in $models) {
        Create-RepositoryFiles $model
    }

    # Crear interfaces y clases de service
    foreach ($model in $models) {
        Create-ServiceFiles $model
    }

    # Crear controladores
    foreach ($model in $models) {
        Create-ControllerFile $model
    }

    # Actualizar el Program.cs para la inyección de dependencias
    $dependencyInjections = @"
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
"@
    foreach ($model in $models) {
        $dependencyInjections += @"
builder.Services.AddScoped<I${model}Repository, ${model}Repository>();
builder.Services.AddScoped<I${model}Service, ${model}Service>();
"@
    }
    $dependencyInjections += @"
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
"@

    Set-Content -Path "Program.cs" -Value @"
using $projectName.Repositories;
using $projectName.Services;

$dependencyInjections
"@

    Write-Host "Estructura del proyecto '$projectName' creada exitosamente"
} catch {
    Write-Host "Ocurrió un error: $_"
    Write-Host "Cancelando la creación del proyecto..."
    Exit 1
}

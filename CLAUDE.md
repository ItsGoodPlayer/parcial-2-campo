# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a C# Windows Forms restaurant ordering system implementing multiple design patterns as part of a university assignment. The system allows creating orders with combos and additional portions, demonstrating advanced object-oriented programming concepts.

## Architecture

4-layer architecture:
- **GUI**: Windows Forms interface (`Parcial 2 - Campo/`)
- **BLL**: Business Logic Layer with design patterns
- **BE**: Business Entities with domain models and decorators
- **DAL**: Data Access Layer with SQL Server integration

## Build Commands

Build the entire solution:
```bash
dotnet build "Parcial 2 - Campo.sln"
```

Build individual projects:
```bash
dotnet build BE/BE.csproj
dotnet build DAL/DAL.csproj
dotnet build BLL/BLL.csproj
dotnet build "Parcial 2 - Campo/GUI.csproj"
```

Run the application:
```bash
dotnet run --project "Parcial 2 - Campo/GUI.csproj"
```

## Database Setup

Execute the SQL script to create the database:
```sql
-- Run CrearBaseDatos.sql in SQL Server Management Studio
-- Creates McDonalds database with tables: Combos, PorcionesAdicionales, Pedidos, PedidoPorciones
```

## Design Patterns Implemented

1. **Factory Pattern**: `ComboFactory.cs` - Creates different combo types
2. **Singleton Pattern**: `SistemaPedidos.cs` - Single system instance
3. **Template Method Pattern**: `Combo.cs` - Base class for combo types
4. **Decorator Pattern**: `PorcionDecorator.cs` and implementations - Dynamic composition of orders
5. **Builder Pattern**: `PedidoBuilder.cs` - Fluent API for building orders
6. **DAO Pattern**: Separate DAL classes for each entity

## Key Components

### Business Entities (BE)
- `IPedidoComponent.cs` - Interface for decoratable components
- `Combo.cs` - Abstract base class for combos
- `ComboBasico.cs`, `ComboFamiliar.cs`, `ComboEspecial.cs` - Concrete combo implementations
- `PorcionDecorator.cs` - Base decorator class
- `QuesoDecorator.cs`, `CarneDecorator.cs`, `TomateDecorator.cs`, `PapasDecorator.cs` - Specific decorators

### Business Logic (BLL)
- `PedidoBuilder.cs` - Builder pattern for order construction
- `SistemaPedidos.cs` - Singleton managing the order system
- `ComboFactory.cs` - Factory for creating combo instances

### Data Access (DAL)
- `AccesoDAL.cs` - Base class with common database operations
- `PedidoDAL.cs`, `ComboDAL.cs`, `PorcionAdicionalDAL.cs` - Entity-specific data access

## Development Notes

- Target Framework: .NET Framework 4.7.2
- Database: SQL Server with EntityFramework-like pattern
- The system demonstrates decorator pattern through dynamic composition of orders
- Builder pattern provides fluent API for creating complex orders
- All decorators automatically calculate prices through composition

## Usage Example

```csharp
// Create an order using Builder pattern with Decorator pattern
var pedido = new PedidoBuilder(TipoCombo.Basico)
    .AgregarQueso()      // +$800
    .AgregarCarne()      // +$2000
    .AgregarTomate()     // +$500
    .Construir();

// Result: "Combo Básico + Queso + Carne + Tomate" = $8300
```

## Testing

No automated testing framework is configured. Manual testing through the Windows Forms interface.

## Project Dependencies

- System.Data for SQL Server connectivity
- Windows Forms for UI
- Inter-project references: GUI → BLL → BE/DAL
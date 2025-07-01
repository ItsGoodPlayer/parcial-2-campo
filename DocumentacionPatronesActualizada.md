# Documentación Actualizada - Patrones de Diseño
## Sistema de Pedidos del Restaurante con Decorator Pattern

### 📋 Índice
1. [Arquitectura General](#arquitectura-general)
2. [Patrones de Diseño Implementados](#patrones-de-diseño-implementados)
3. [Nuevo Patrón: Decorator](#nuevo-patrón-decorator)
4. [Builder Pattern](#builder-pattern)
5. [Estructura Actualizada](#estructura-actualizada)
6. [Beneficios de la Refactorización](#beneficios-de-la-refactorización)

---

## Arquitectura General

El sistema mantiene la **Arquitectura de N-Capas** pero ahora incorpora el **Decorator Pattern** para la composición dinámica de pedidos:

```
┌─────────────────────────────────────┐
│               GUI                   │ ← Interfaz de Usuario
│          (Windows Forms)            │
├─────────────────────────────────────┤
│               BLL                   │ ← Lógica de Negocio
│    (PedidoBuilder + SistemaPedidos) │   + Decorator Pattern
├─────────────────────────────────────┤
│               BE                    │ ← Entidades + Decorators
│  (IPedidoComponent + Decorators)    │
├─────────────────────────────────────┤
│               DAL                   │ ← Acceso a Datos
│        (Especializado por entidad)  │
├─────────────────────────────────────┤
│           SQL Server                │ ← Base de Datos
│            Database                 │
└─────────────────────────────────────┘
```

---

## Patrones de Diseño Implementados

### 1. 🏭 Factory Pattern

**Mantiene su implementación original** en `ComboFactory.cs` pero ahora trabaja con la interfaz `IPedidoComponent`:

```csharp
public static Combo CrearCombo(TipoCombo tipo)
{
    switch (tipo)
    {
        case TipoCombo.Basico:
            return new ComboBasico();    // Implementa IPedidoComponent
        case TipoCombo.Familiar:
            return new ComboFamiliar();  // Implementa IPedidoComponent
        case TipoCombo.Especial:
            return new ComboEspecial();  // Implementa IPedidoComponent
        default:
            return new ComboBasico();
    }
}
```

### 2. 🎯 Singleton Pattern

**Simplificado para entorno de pruebas** en `SistemaPedidos.cs`:

```csharp
public static SistemaPedidos ObtenerInstancia()
{
    if (_instancia == null)
    {
        _instancia = new SistemaPedidos();
    }
    return _instancia;
}
```

**Cambio principal:** Ahora maneja `PedidoBuilder` en lugar de `Pedido` directamente.

### 3. 📝 Template Method Pattern

**Extendido con la interfaz** `IPedidoComponent`:

```csharp
public abstract class Combo : IPedidoComponent
{
    // Propiedades base existentes...
    
    // Nuevos métodos de la interfaz
    public string ObtenerDescripcion() => Nombre;
    public abstract List<string> ObtenerIngredientes();
    public TipoCombo ObtenerTipoComboBase() => Tipo;
}
```

### 4. 🎨 **NUEVO: Decorator Pattern**

**Implementación principal** para composición dinámica de pedidos:

#### **Interfaz Base:**
```csharp
public interface IPedidoComponent
{
    decimal CalcularPrecio();
    string ObtenerDescripcion();
    List<string> ObtenerIngredientes();
    TipoCombo ObtenerTipoComboBase();
}
```

#### **Decorator Base:**
```csharp
public abstract class PorcionDecorator : IPedidoComponent
{
    protected IPedidoComponent componente;
    
    protected PorcionDecorator(IPedidoComponent componente)
    {
        this.componente = componente;
    }
    
    public virtual decimal CalcularPrecio() => componente.CalcularPrecio();
    public virtual string ObtenerDescripcion() => componente.ObtenerDescripcion();
    public virtual List<string> ObtenerIngredientes() => new List<string>(componente.ObtenerIngredientes());
    public virtual TipoCombo ObtenerTipoComboBase() => componente.ObtenerTipoComboBase();
}
```

#### **Decorators Específicos:**
```csharp
public class QuesoDecorator : PorcionDecorator
{
    private const decimal PRECIO_QUESO = 800m;
    
    public override decimal CalcularPrecio() => componente.CalcularPrecio() + PRECIO_QUESO;
    public override string ObtenerDescripcion() => componente.ObtenerDescripcion() + " + Queso";
    public override List<string> ObtenerIngredientes()
    {
        var ingredientes = base.ObtenerIngredientes();
        ingredientes.Add("Queso extra");
        return ingredientes;
    }
}
// CarneDecorator, TomateDecorator, PapasDecorator siguen el mismo patrón
```

### 5. 🏗️ **NUEVO: Builder Pattern**

**Implementación en** `PedidoBuilder.cs` para construir pedidos con decorators:

```csharp
public class PedidoBuilder
{
    private IPedidoComponent _pedidoComponent;

    public PedidoBuilder(TipoCombo tipoCombo)
    {
        _pedidoComponent = ComboFactory.CrearCombo(tipoCombo);
    }

    public PedidoBuilder AgregarQueso()
    {
        _pedidoComponent = new QuesoDecorator(_pedidoComponent);
        return this;
    }
    
    // Métodos fluent para agregar otras porciones...
    
    public IPedidoComponent Construir() => _pedidoComponent;
    public decimal ObtenerPrecioTotal() => _pedidoComponent.CalcularPrecio();
}
```

### 6. 🏗️ Data Access Object (DAO) Pattern

**Mantiene la separación por entidades** implementada anteriormente:
- `PedidoDAL.cs`
- `ComboDAL.cs`  
- `PorcionAdicionalDAL.cs`
- `AccesoDAL.cs` (clase base)

---

## Nuevo Patrón: Decorator

### **¿Por qué Decorator Pattern?**

1. **🧩 Composición Dinámica**: Permite agregar porciones en tiempo de ejecución
2. **🔄 Flexibilidad**: Diferentes combinaciones sin explosión de clases
3. **📏 Single Responsibility**: Cada decorator maneja una responsabilidad específica
4. **🎨 Extensibilidad**: Agregar nuevas porciones sin modificar código existente
5. **💰 Cálculo Automático**: El precio se calcula por composición automática

### **Ejemplo de Uso:**

```csharp
// Fluent API con Builder
var pedido = new PedidoBuilder(TipoCombo.Basico)
    .AgregarQueso()      // +$800
    .AgregarCarne()      // +$2000
    .AgregarTomate()     // +$500
    .Construir();

// Resultado: "Combo Básico + Queso + Carne + Tomate" = $8300
Console.WriteLine(pedido.ObtenerDescripcion());
Console.WriteLine($"Total: ${pedido.CalcularPrecio()}");
```

### **Comparación Antes vs Después:**

| **Antes (Lista de PorcionAdicional)** | **Después (Decorator Pattern)** |
|---------------------------------------|----------------------------------|
| Manejo manual de listas | Composición automática |
| Cálculo manual de totales | Cálculo automático por decoración |
| Difícil quitar porciones específicas | Reconstrucción limpia |
| Código procedural | Orientado a objetos puro |

---

## Builder Pattern

### **¿Por qué Builder Pattern?**

El Builder complementa perfectamente al Decorator:

1. **🔗 Fluent Interface**: API fácil de usar y leer
2. **🎯 Encapsulación**: Oculta la complejidad de decoración
3. **🔄 Flexibilidad**: Permite construcción paso a paso
4. **🧹 Conversión**: Convierte entre Decorator y Pedido para persistencia

### **Flujos de Trabajo:**

```csharp
// 1. Crear pedido con Builder
var builder = new PedidoBuilder(TipoCombo.Especial);

// 2. Agregar porciones dinámicamente
builder.AgregarQueso().AgregarCarne();

// 3. Obtener información en tiempo real
decimal total = builder.ObtenerPrecioTotal();
string descripcion = builder.ObtenerDescripcionCompleta();

// 4. Convertir para persistencia
Pedido pedidoParaGuardar = builder.ConvertirAPedido();
```

---

## Estructura Actualizada

### 📊 **Capa BE (Business Entities)**

**Nuevos archivos:**
- `IPedidoComponent.cs` - Interfaz para componentes decorables
- `PorcionDecorator.cs` - Clase base para decorators
- `QuesoDecorator.cs`, `CarneDecorator.cs`, `TomateDecorator.cs`, `PapasDecorator.cs`

**Archivos modificados:**
- `ComboBasico.cs`, `ComboFamiliar.cs`, `ComboEspecial.cs` - Implementan `IPedidoComponent`
- `Pedido.cs` - Simplificado, solo para persistencia

### 🧠 **Capa BLL (Business Logic Layer)**

**Nuevos archivos:**
- `PedidoBuilder.cs` - Builder para construir pedidos con decorators

**Archivos modificados:**
- `SistemaPedidos.cs` - Usa `PedidoBuilder` en lugar de `Pedido` directamente
- `ComboFactory.cs` - Mantiene compatibilidad con `IPedidoComponent`

### 💾 **Capa DAL (Data Access Layer)**

**Sin cambios significativos** - Mantiene la separación por entidades implementada anteriormente.

### 🖥️ **Capa GUI (Graphical User Interface)**

**Archivos modificados:**
- `Form1.cs` - Adaptado para trabajar con el nuevo sistema de decorators
- Misma experiencia de usuario, mejor lógica interna

---

## Beneficios de la Refactorización

### 🎯 **Ventajas Técnicas:**

1. **🧩 Composición vs Herencia**: Más flexible que crear subclases para cada combinación
2. **🔄 Extensibilidad**: Agregar nuevas porciones sin tocar código existente
3. **📏 SOLID Principles**: Mejor adherencia a principios de diseño
4. **🎨 Patrón Reconocido**: Implementación estándar del Decorator Pattern
5. **💰 Cálculo Automático**: Sin errores manuales en cálculos

### 📈 **Ventajas de Negocio:**

1. **🚀 Escalabilidad**: Fácil agregar nuevos tipos de porciones
2. **🔧 Mantenibilidad**: Cada decorator es independiente
3. **🎯 Precisión**: Cálculos automáticos sin errores
4. **🔄 Flexibilidad**: Pedidos más complejos sin complejidad de código

### 🎓 **Ventajas Académicas:**

1. **📚 Múltiples Patrones**: Demuestra dominio de varios patrones
2. **🔄 Evolución**: Muestra cómo refactorizar hacia mejores prácticas
3. **🧠 Pensamiento OOP**: Aplicación avanzada de POO
4. **💡 Casos Reales**: Patrones aplicados a problemas reales

---

## 🎯 Resultado Final

**El sistema ahora implementa 6 patrones de diseño:**

1. ✅ **Factory Pattern** - Creación de combos
2. ✅ **Singleton Pattern** - Sistema único de pedidos
3. ✅ **Template Method Pattern** - Estructura común de combos
4. ✅ **DAO Pattern** - Acceso a datos especializado
5. ✅ **Decorator Pattern** - Composición dinámica de pedidos
6. ✅ **Builder Pattern** - Construcción fluida de pedidos

**Características destacadas:**
- 🎨 Código más elegante y orientado a objetos
- 🔄 Fácil extensión para nuevas funcionalidades
- 💰 Cálculo automático y preciso de precios
- 🧹 Separación clara de responsabilidades
- 📚 Implementación académica ejemplar
- ✅ Funcionalidad completa mantenida
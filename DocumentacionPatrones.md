# Documentación de Patrones de Diseño y Arquitectura
## Sistema de Pedidos del Restaurante

### 📋 Índice
1. [Arquitectura General](#arquitectura-general)
2. [Patrones de Diseño Implementados](#patrones-de-diseño-implementados)
3. [Estructura de Capas](#estructura-de-capas)
4. [Justificación de Decisiones](#justificación-de-decisiones)

---

## Arquitectura General

El sistema está implementado usando una **Arquitectura de N-Capas** (3 capas + GUI) que separa claramente las responsabilidades:

```
┌─────────────────────────────────────┐
│               GUI                   │ ← Interfaz de Usuario
│          (Windows Forms)            │
├─────────────────────────────────────┤
│               BLL                   │ ← Lógica de Negocio
│        (Business Logic Layer)       │
├─────────────────────────────────────┤
│               BE                    │ ← Entidades de Negocio
│       (Business Entities)           │
├─────────────────────────────────────┤
│               DAL                   │ ← Acceso a Datos
│        (Data Access Layer)          │
├─────────────────────────────────────┤
│           SQL Server                │ ← Base de Datos
│            Database                 │
└─────────────────────────────────────┘
```

---

## Patrones de Diseño Implementados

### 1. 🏭 Factory Pattern

**Implementación:** `ComboFactory.cs`

```csharp
public class ComboFactory
{
    public static Combo CrearCombo(TipoCombo tipo)
    {
        switch (tipo)
        {
            case TipoCombo.Basico:
                return new ComboBasico();
            case TipoCombo.Familiar:
                return new ComboFamiliar();
            case TipoCombo.Especial:
                return new ComboEspecial();
            default:
                return new ComboBasico();
        }
    }
}
```

**¿Por qué Factory Pattern?**
- **Encapsulación de la creación**: El cliente no necesita conocer las clases concretas
- **Flexibilidad**: Fácil agregar nuevos tipos de combos sin modificar código existente
- **Mantenibilidad**: Centraliza la lógica de creación de objetos
- **Polimorfismo**: Trabaja con la clase abstracta `Combo`

**Beneficios implementados:**
- Si el restaurante agrega un "Combo Premium", solo se modifica el Factory
- El código cliente siempre trabaja con la abstracción `Combo`
- Facilita testing al poder mockear la creación

### 2. 🎯 Singleton Pattern

**Implementación:** `SistemaPedidos.cs`

```csharp
public class SistemaPedidos
{
    private static SistemaPedidos _instancia;

    private SistemaPedidos()
    {
        _pedidoDAL = new PedidoDAL();
        _porcionDAL = new PorcionAdicionalDAL();
        HistorialPedidos = new List<Pedido>();
        CargarHistorial();
    }

    public static SistemaPedidos ObtenerInstancia()
    {
        if (_instancia == null)
        {
            _instancia = new SistemaPedidos();
        }
        return _instancia;
    }
}
```

**¿Por qué Singleton Pattern?**
- **Estado global**: El sistema debe mantener un pedido actual único
- **Consistencia**: Evita múltiples instancias que podrían causar inconsistencias
- **Gestión de recursos**: Una sola conexión al historial de pedidos
- **Simplicidad**: Implementación simple para entorno de pruebas

**Beneficios implementados:**
- Garantiza que solo hay un pedido actual en toda la aplicación
- Mantiene consistencia en el historial de pedidos
- Código simple y fácil de entender para fines académicos

### 3. 📝 Template Method Pattern

**Implementación:** Clase abstracta `Combo.cs`

```csharp
public abstract class Combo
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string Descripcion { get; set; }
    public TipoCombo Tipo { get; set; }

    public virtual decimal CalcularPrecio()
    {
        return Precio;
    }

    public virtual string ObtenerDetalle()
    {
        return $"{Nombre} - ${Precio:N0} - {Descripcion}";
    }
}
```

**¿Por qué Template Method Pattern?**
- **Estructura común**: Todos los combos tienen las mismas propiedades base
- **Extensibilidad**: Permite especialización en clases derivadas
- **Reutilización**: Evita duplicación de código común
- **Polimorfismo**: Facilita el tratamiento uniforme de diferentes combos

**Beneficios implementados:**
- Las clases `ComboBasico`, `ComboFamiliar`, `ComboEspecial` heredan comportamiento común
- Fácil extensión para agregar nuevos tipos de combo
- Métodos virtuales permiten personalización específica

### 4. 🏗️ Data Access Object (DAO) Pattern

**Implementación:** Clases DAL separadas por entidad

```csharp
// Clase base abstracta
public abstract class AccesoDAL
{
    protected SqlConnection conexion;
    protected SqlTransaction transaccion;
    // Métodos comunes protected...
}

// Implementaciones específicas
public class PedidoDAL : AccesoDAL { }
public class ComboDAL : AccesoDAL { }
public class PorcionAdicionalDAL : AccesoDAL { }
```

**¿Por qué DAO Pattern?**
- **Separación de responsabilidades**: Cada DAL maneja su entidad específica
- **Abstracción de datos**: Oculta detalles de persistencia a las capas superiores
- **Mantenibilidad**: Cambios en BD no afectan lógica de negocio
- **Testabilidad**: Fácil crear mocks para testing

**Beneficios implementados:**
- `PedidoDAL` maneja solo operaciones de pedidos
- `ComboDAL` se encarga únicamente de combos
- `PorcionAdicionalDAL` gestiona solo porciones adicionales
- Reutilización de código común en clase base `AccesoDAL`

---

## Estructura de Capas

### 📊 Capa BE (Business Entities)
**Responsabilidad:** Definir las entidades del dominio

**Archivos:**
- `Combo.cs` - Clase abstracta base
- `ComboBasico.cs`, `ComboFamiliar.cs`, `ComboEspecial.cs` - Implementaciones concretas
- `PorcionAdicional.cs` - Entidad de porciones adicionales
- `Pedido.cs` - Entidad principal del pedido
- `TipoCombo.cs`, `TipoPorcion.cs` - Enumeraciones

**Características:**
- Sin dependencias externas
- Solo contiene propiedades y lógica de dominio
- Utilizada por todas las demás capas

### 🧠 Capa BLL (Business Logic Layer)
**Responsabilidad:** Implementar reglas de negocio y orquestar operaciones

**Archivos:**
- `ComboFactory.cs` - Patrón Factory para crear combos
- `SistemaPedidos.cs` - Patrón Singleton para gestión de pedidos

**Características:**
- Depende de BE y DAL
- Implementa las reglas de negocio del restaurante
- Orquesta las operaciones entre DAL y GUI

### 💾 Capa DAL (Data Access Layer)
**Responsabilidad:** Acceso y persistencia de datos

**Archivos:**
- `AccesoDAL.cs` - Clase base abstracta con funcionalidades comunes
- `PedidoDAL.cs` - Operaciones específicas de pedidos
- `ComboDAL.cs` - Operaciones específicas de combos
- `PorcionAdicionalDAL.cs` - Operaciones específicas de porciones

**Características:**
- Implementa patrón DAO
- Manejo de transacciones SQL Server
- Separación por entidades para mejor mantenibilidad

### 🖥️ Capa GUI (Graphical User Interface)
**Responsabilidad:** Interfaz de usuario

**Archivos:**
- `Form1.cs` - Lógica de la interfaz
- `Form1.Designer.cs` - Diseño de controles

**Características:**
- Solo depende de BLL y BE
- No conoce detalles de persistencia
- Interfaz simple y funcional

---

## Justificación de Decisiones

### ¿Por qué Arquitectura en Capas?
1. **Separación de responsabilidades**: Cada capa tiene un propósito específico
2. **Mantenibilidad**: Cambios en una capa no afectan las demás
3. **Testabilidad**: Cada capa puede probarse independientemente
4. **Escalabilidad**: Fácil agregar funcionalidades sin romper código existente

### ¿Por qué estos Patrones específicos?
1. **Factory**: El sistema necesita crear diferentes tipos de combos dinámicamente
2. **Singleton**: Solo debe existir un sistema de pedidos activo
3. **Template Method**: Los combos comparten estructura pero difieren en detalles
4. **DAO**: Diferentes entidades requieren diferentes operaciones de datos

### ¿Por qué SQL Server en lugar de archivos?
1. **Integridad**: Transacciones ACID para consistencia de datos
2. **Concurrencia**: Múltiples usuarios simultáneos en el futuro
3. **Escalabilidad**: Preparado para crecimiento del negocio
4. **Consultas**: SQL permite consultas complejas del historial

### ¿Por qué separar DAL por entidades?
1. **Principio de Responsabilidad Única**: Cada clase tiene una razón para cambiar
2. **Mantenibilidad**: Más fácil localizar y modificar código específico
3. **Reutilización**: Métodos comunes en clase base
4. **Testabilidad**: Testing granular por entidad

---

## 🎯 Resultado Final

**Beneficios del diseño implementado:**
- ✅ Código mantenible y extensible
- ✅ Separación clara de responsabilidades  
- ✅ Fácil testing y debugging
- ✅ Preparado para futuras expansiones
- ✅ Buenas prácticas de programación orientada a objetos
- ✅ Persistencia robusta con SQL Server
- ✅ Interfaz de usuario simple y efectiva

**El sistema cumple completamente con los requerimientos:**
- Sistema de pedidos funcional ✅
- Diferentes tipos de combos ✅
- Porciones adicionales ✅
- Cálculo de totales ✅
- Persistencia de historial ✅
- Interfaz de usuario completa ✅
- Implementación de patrones de diseño ✅
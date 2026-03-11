# C# XML Documentation — Cheatsheet & Standards

> **Purpose:** Reference guide for consistent XML documentation across all project layers.
> **Convention:** English only — all summaries, remarks, params, and returns must be written in English.
> **Rule:** Documentation must add value — never paraphrase the code itself.

---

## Table of Contents

1. [XML Tags Reference](#xml-tags-reference)
2. [Standard Cases](#standard-cases)
   - [Class / Struct](#class--struct)
   - [Interface](#interface)
   - [Property](#property)
   - [Method](#method)
3. [Layer-Specific Standards](#layer-specific-standards)
   - [Core.Abstractions — Interfaces](#coreabstractions--interfaces)
   - [Core.Abstractions — Value Objects](#coreabstractions--value-objects)
   - [Core.Domain — Entities](#coredomain--entities)
   - [Core.Domain — Enums](#coredomain--enums)
   - [Core.Domain — Domain Services](#coredomain--domain-services)
   - [Application — Use Cases](#application--use-cases)
   - [Application — DTOs](#application--dtos)
   - [Infrastructure — DbContext](#infrastructure--dbcontext)
   - [Infrastructure — Repositories](#infrastructure--repositories)
   - [Infrastructure — Value Converters](#infrastructure--value-converters)
   - [Presentation — Controllers](#presentation--controllers)

---

## XML Tags Reference

| Tag | Usage | Mandatory |
|---|---|---|
| `<summary>` | One-line description of the member | ✅ Always |
| `<remarks>` | Additional context, rules, constraints, links | When behaviour needs explanation |
| `<typeparam name="T">` | Description of a generic type parameter | When generic |
| `<param name="x">` | Description of a method parameter | When method has parameters |
| `<returns>` | Description of the return value | When method returns a value |
| `<exception cref="T">` | Documents a thrown exception and its condition | When method throws |
| `<value>` | Describes a property's value | When property needs clarification |
| `<example>` + `<code>` | Usage example | When usage is non-obvious |
| `<see cref="T"/>` | Inline reference to another type or member | When referencing related members |
| `<seealso cref="T"/>` | Related type listed at the bottom of the doc | When referencing related concepts |
| `<list type="bullet">` | Bullet list inside remarks or exception | When listing rules or conditions |
| `<para>` | New paragraph inside a block tag | When remarks need structure |
| `<inheritdoc/>` | Inherit documentation from base or interface | On overrides and implementations |

---

## Standard Cases

### Class / Struct

```csharp
/// <summary>
/// [Represents / Provides] [what the class is or does — one sentence].
/// </summary>
/// <remarks>
/// [Optional: why it exists, its constraints, its role in the system.]
/// [Optional: link to external specification or related concept.]
/// </remarks>
/// <example>
/// [Optional: short usage example when instantiation is non-obvious.]
/// <code>
/// var instance = new MyClass(param);
/// </code>
/// </example>
public class MyClass { }
```

**Triggers:**
- `Represents` → entity, value object, model
- `Provides` → service, helper, factory
- `Encapsulates` → wrapper, adapter

---

### Interface

```csharp
/// <summary>
/// Defines the contract for [what implementors must provide — one sentence].
/// </summary>
/// <typeparam name="TId">
/// [What the type parameter represents and any constraint rationale.]
/// </typeparam>
/// <remarks>
/// [Optional: architectural intent, where this interface fits in the system.]
/// [Optional: list of known implementations with <see cref="T"/>.]
/// </remarks>
public interface IMyInterface<TId> where TId : IId { }
```

**Trigger:** Always starts with `Defines the contract for`.

---

### Property

```csharp
/// <summary>
/// Gets [or sets] [what the property represents — one sentence].
/// </summary>
/// <value>
/// [Optional: the type and range of acceptable values when not obvious.]
/// </value>
public string Name { get; init; }
```

**Triggers:**
- Read-only → `Gets`
- Read-write → `Gets or sets`
- `<value>` → only when the acceptable range or type needs clarification

---

### Method

```csharp
/// <summary>
/// [Verb at 3rd person singular] [what the method does — one sentence].
/// </summary>
/// <param name="paramName">
/// [What the parameter represents. Include constraints if any.]
/// </param>
/// <param name="cancellationToken">
/// A token to observe for cancellation requests.
/// </param>
/// <returns>
/// A <see cref="Task{TResult}"/> representing the asynchronous operation,
/// containing [what the result is].
/// </returns>
/// <exception cref="ArgumentNullException">
/// Thrown when <paramref name="paramName"/> is <see langword="null"/>.
/// </exception>
/// <exception cref="DomainException">
/// Thrown when [business rule violated]:
/// <list type="bullet">
///   <item>[First condition.]</item>
///   <item>[Second condition.]</item>
/// </list>
/// </exception>
public async Task<MyResult> DoSomethingAsync(
    MyParam paramName,
    CancellationToken cancellationToken = default) { }
```

**Triggers by return type:**

| Return type | `<returns>` pattern |
|---|---|
| `void` | Omit `<returns>` |
| `Task` | `A <see cref="Task"/> representing the asynchronous operation.` |
| `Task<T>` | `A <see cref="Task{T}"/> [...], containing [the result].` |
| `T` | `[The result] if found; otherwise [fallback or exception].` |
| `bool` | `<see langword="true"/> if [...]; otherwise <see langword="false"/>.` |
| `T?` | `[The entity] if found; otherwise <see langword="null"/>.` |

---

## Layer-Specific Standards

---

### Core.Abstractions — Interfaces

**Intent:** Define contracts. No implementation detail — only the **what**, never the **how**.

```csharp
/// <summary>
/// Defines the contract for entities that carry a strongly-typed identifier.
/// </summary>
/// <typeparam name="TId">
/// The type of the identifier. Must implement <see cref="IId"/>
/// to ensure only domain-approved identifier types are used.
/// </typeparam>
/// <remarks>
/// All domain entities must implement this interface to guarantee
/// consistent identity management across persistence and application layers.
/// </remarks>
/// <seealso cref="IId"/>
/// <seealso cref="IAuditable"/>
/// <seealso cref="ISoftDeletable"/>
public interface IIdentifiable<TId> where TId : IId
{
    /// <summary>
    /// Gets the unique identifier of the entity.
    /// </summary>
    TId Id { get; }
}
```

**Rules:**
- `<remarks>` must explain **why** the contract exists in the system.
- `<seealso>` must reference sibling interfaces when applicable.
- Never document **how** an implementor should work — that belongs on the implementation.

---

### Core.Abstractions — Value Objects

**Intent:** Document immutability, validation rules, and conversion operators.

```csharp
/// <summary>
/// Represents a Discord Snowflake identifier — a unique 64-bit ID
/// encoding a timestamp, worker ID, and sequence number.
/// </summary>
/// <remarks>
/// A Snowflake value is guaranteed to be strictly positive.
/// It is time-sortable by nature and universally unique within Discord's infrastructure.
/// <para>
/// See the official Discord documentation:
/// https://discord.com/developers/docs/reference#snowflakes
/// </para>
/// </remarks>
/// <example>
/// <code>
/// var userId = new Snowflake(123456789012345678L);
/// long raw   = userId; // implicit conversion to long
/// </code>
/// </example>
public readonly struct Snowflake : IEquatable<Snowflake>, IId
{
    /// <summary>
    /// Gets the raw 64-bit value of this Snowflake.
    /// </summary>
    /// <value>
    /// A strictly positive <see cref="long"/> representing the Discord-assigned ID.
    /// </value>
    public long Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Snowflake"/> struct
    /// with the specified raw value.
    /// </summary>
    /// <param name="value">
    /// The raw 64-bit Discord Snowflake value. Must be strictly positive.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="value"/> is zero or negative.
    /// </exception>
    public Snowflake(long value) { }

    /// <summary>
    /// Implicitly converts a <see cref="Snowflake"/> to its raw <see cref="long"/> value.
    /// </summary>
    /// <param name="snowflake">The Snowflake to convert.</param>
    /// <returns>The raw 64-bit value of the Snowflake.</returns>
    public static implicit operator long(Snowflake snowflake) => snowflake.Value;

    /// <summary>
    /// Explicitly converts a <see cref="long"/> to a <see cref="Snowflake"/>.
    /// </summary>
    /// <param name="value">The raw value to convert. Must be strictly positive.</param>
    /// <returns>A new <see cref="Snowflake"/> wrapping the provided value.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="value"/> is zero or negative.
    /// </exception>
    public static explicit operator Snowflake(long value) => new(value);
}
```

**Rules:**
- Always document conversion operators — their directionality is not always obvious.
- `<value>` is mandatory on properties that hold the core wrapped primitive.
- `<remarks>` must include the external specification link when the type maps to an external standard.

---

### Core.Domain — Entities

**Intent:** Document invariants, lifecycle, and business rules enforced by the entity.

```csharp
/// <summary>
/// Represents a registered user in the system,
/// associating a Discord identity with a specific guild.
/// </summary>
/// <remarks>
/// A User is uniquely identified by the combination of
/// <see cref="DiscordId"/> and <see cref="GuildId"/>.
/// <para>
/// Users are never permanently deleted — deactivation is performed
/// via <see cref="Deactivate"/> following the soft-delete pattern.
/// </para>
/// </remarks>
/// <seealso cref="Player"/>
public sealed class User : IIdentifiable<Guid>, IAuditable, ISoftDeletable
{
    /// <summary>
    /// Gets the unique internal identifier of this user.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the Discord Snowflake identifier of this user.
    /// </summary>
    public Snowflake DiscordId { get; init; }

    /// <summary>
    /// Gets the Discord Snowflake identifier of the guild this user belongs to.
    /// </summary>
    public Snowflake GuildId { get; init; }

    /// <summary>
    /// Gets a value indicating whether this user is currently active in the system.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the user is active; otherwise <see langword="false"/>.
    /// </value>
    public bool IsActive { get; private set; }

    /// <summary>
    /// Deactivates this user, recording the date and time of departure.
    /// </summary>
    /// <remarks>
    /// Calling this method on an already inactive user has no effect —
    /// the original <see cref="LeftAt"/> value is preserved.
    /// </remarks>
    public void Deactivate() { }
}
```

**Rules:**
- `<remarks>` on the class must state the uniqueness constraints and lifecycle rules.
- Business rule methods (`Deactivate`, `Promote`...) must document their idempotency and side effects.
- Navigation properties (EF Core) do not require `<summary>` unless they carry business meaning.

---

### Core.Domain — Enums

**Intent:** Document each member's business meaning and any associated constraint.

```csharp
/// <summary>
/// Defines the possible roles a player can hold within a team.
/// </summary>
public enum TeamRole
{
    /// <summary>
    /// A confirmed starting player.
    /// A team may have at most 5 active Lock players simultaneously.
    /// </summary>
    Lock = 0,

    /// <summary>
    /// A substitute player available to replace a Lock when needed.
    /// A player may hold the Sub role in multiple teams simultaneously.
    /// </summary>
    Sub = 1,

    /// <summary>
    /// A player currently on trial.
    /// A Tryout may be promoted to <see cref="Lock"/> or <see cref="Sub"/>.
    /// Promotion history is preserved via membership lifecycle records.
    /// </summary>
    Tryout = 2
}
```

**Rules:**
- Each member must document its **business constraint**, not just its name.
- Use `<see cref=""/>` to cross-reference related members when a transition exists.

---

### Core.Domain — Domain Services

**Intent:** Document the business rules enforced, not the technical implementation.

```csharp
/// <summary>
/// Defines the contract for team membership domain operations,
/// enforcing business rules on player roles and transitions.
/// </summary>
/// <remarks>
/// This service is responsible for all state transitions within a
/// <see cref="Team"/>, including member addition, removal, and role promotion.
/// <para>Business rules enforced:</para>
/// <list type="bullet">
///   <item>A team may not have more than 5 active <see cref="TeamRole.Lock"/> players.</item>
///   <item>A player may hold the Lock role in at most one team per guild.</item>
///   <item>Promoting a Tryout to Lock closes the current membership and opens a new one.</item>
/// </list>
/// </remarks>
public interface ITeamDomainService
{
    /// <summary>
    /// Adds a player to the specified team with the given role,
    /// enforcing all membership constraints.
    /// </summary>
    /// <param name="team">The team to add the player to.</param>
    /// <param name="player">The player to add.</param>
    /// <param name="role">The role assigned to the player.</param>
    /// <param name="cancellationToken">A token to observe for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
    /// containing the newly created <see cref="TeamMembership"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="team"/> or <paramref name="player"/>
    /// is <see langword="null"/>.
    /// </exception>
    /// <exception cref="DomainException">
    /// Thrown when adding the player violates one of the following rules:
    /// <list type="bullet">
    ///   <item>The team already has 5 active Lock players.</item>
    ///   <item>The player is already a Lock in another team within the same guild.</item>
    /// </list>
    /// </exception>
    Task<TeamMembership> AddMemberAsync(
        Team team,
        Player player,
        TeamRole role,
        CancellationToken cancellationToken = default);
}
```

**Rules:**
- Business rules belong in `<remarks>` on the interface, not on each method.
- Each `<exception>` must list every condition that can trigger it.

---

### Application — Use Cases

**Intent:** Document the command/query intent and the observable outcome.

```csharp
/// <summary>
/// Represents the input data required to register a new user in the system.
/// </summary>
/// <param name="DiscordId">The Discord Snowflake ID of the user to register.</param>
/// <param name="GuildId">The Discord Snowflake ID of the guild the user belongs to.</param>
public sealed record RegisterUserCommand(Snowflake DiscordId, Snowflake GuildId);

/// <summary>
/// Handles the <see cref="RegisterUserCommand"/> use case,
/// creating a new user or reactivating an existing inactive one.
/// </summary>
/// <remarks>
/// If a user matching the provided <c>DiscordId</c> and <c>GuildId</c>
/// already exists and is inactive, the user is reactivated rather than duplicated.
/// </remarks>
public sealed class RegisterUserHandler
{
    /// <summary>
    /// Processes the <see cref="RegisterUserCommand"/> and persists the result.
    /// </summary>
    /// <param name="command">The command containing the registration data.</param>
    /// <param name="cancellationToken">A token to observe for cancellation requests.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
    /// containing the <see cref="Guid"/> of the registered or reactivated user.
    /// </returns>
    /// <exception cref="ConflictException">
    /// Thrown when a user with the same <c>DiscordId</c> and <c>GuildId</c>
    /// already exists and is active.
    /// </exception>
    public Task<Guid> HandleAsync(
        RegisterUserCommand command,
        CancellationToken cancellationToken = default) { }
}
```

**Rules:**
- The handler `<summary>` must reference the command it handles via `<see cref=""/>`.
- `<remarks>` must document idempotency or special branching logic.

---

### Application — DTOs

**Intent:** Document the contract exposed to the consumer — field meaning and nullability.

```csharp
/// <summary>
/// Represents the API response payload for a registered user.
/// </summary>
public sealed record UserResponse
{
    /// <summary>
    /// Gets the internal unique identifier of the user.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the raw Discord Snowflake ID of the user.
    /// </summary>
    public long DiscordId { get; init; }

    /// <summary>
    /// Gets the raw Discord Snowflake ID of the guild this user belongs to.
    /// </summary>
    public long GuildId { get; init; }

    /// <summary>
    /// Gets the player profile associated with this user,
    /// or <see langword="null"/> if no player has been registered.
    /// </summary>
    public PlayerResponse? Player { get; init; }
}
```

**Rules:**
- Nullable properties must explicitly state the `null` condition in `<summary>`.
- DTOs do not need `<remarks>` unless a field has a non-obvious mapping or transformation.

---

### Infrastructure — DbContext

**Intent:** Document the schema responsibility and any global configuration applied.

```csharp
/// <summary>
/// Represents the Entity Framework Core database context for the application,
/// providing access to all persisted domain entities.
/// </summary>
/// <remarks>
/// This context applies the following global configurations:
/// <list type="bullet">
///   <item>Soft-delete query filters on all <see cref="ISoftDeletable"/> entities.</item>
///   <item><see cref="Snowflake"/> value conversions via <see cref="SnowflakeConverter"/>.</item>
///   <item>All entity configurations are loaded from the current assembly.</item>
/// </list>
/// </remarks>
public sealed class AppDbContext : DbContext
{
    /// <summary>
    /// Gets the <see cref="DbSet{TEntity}"/> for <see cref="User"/> entities.
    /// </summary>
    public DbSet<User> Users => Set<User>();

    /// <summary>
    /// Gets the <see cref="DbSet{TEntity}"/> for <see cref="Player"/> entities.
    /// </summary>
    public DbSet<Player> Players => Set<Player>();

    /// <summary>
    /// Configures the model schema by applying all entity type configurations
    /// defined in the current assembly.
    /// </summary>
    /// <param name="modelBuilder">
    /// The builder used to construct the model for this context.
    /// </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}
```

**Rules:**
- `<remarks>` on the class must list every global convention or filter applied.
- `DbSet` properties only need a one-line `<summary>` — the entity name is self-explanatory.

---

### Infrastructure — Repositories

**Intent:** Document query behaviour, filter side effects, and persistence guarantees.

```csharp
/// <summary>
/// Provides Entity Framework Core-based persistence operations for <see cref="User"/> entities.
/// </summary>
/// <remarks>
/// All queries automatically exclude inactive users via the global soft-delete
/// query filter defined in <see cref="AppDbContext"/>.
/// </remarks>
public sealed class UserRepository : IRepository<User, Guid>
{
    /// <inheritdoc/>
    public async Task<User?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) { }

    /// <summary>
    /// Retrieves a user by their Discord identity within a specific guild.
    /// </summary>
    /// <param name="discordId">The Discord Snowflake ID of the user.</param>
    /// <param name="guildId">The Discord Snowflake ID of the guild.</param>
    /// <param name="cancellationToken">A token to observe for cancellation requests.</param>
    /// <returns>
    /// The matching <see cref="User"/> if found and active;
    /// otherwise <see langword="null"/>.
    /// </returns>
    public async Task<User?> GetByDiscordAndGuildAsync(
        Snowflake discordId,
        Snowflake guildId,
        CancellationToken cancellationToken = default) { }
}
```

**Rules:**
- Use `<inheritdoc/>` for methods directly implementing the `IRepository` contract.
- Repository-specific query methods must document filter behaviour explicitly.
- Always state whether soft-deleted records are included or excluded.

---

### Infrastructure — Value Converters

**Intent:** Document the conversion direction and the storage type used.

```csharp
/// <summary>
/// Converts a <see cref="Snowflake"/> value object to and from
/// its <see cref="long"/> database representation.
/// </summary>
/// <remarks>
/// Registered globally in <see cref="AppDbContext"/> for all properties
/// of type <see cref="Snowflake"/> across the model.
/// </remarks>
public sealed class SnowflakeConverter : ValueConverter<Snowflake, long>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SnowflakeConverter"/> class,
    /// defining the conversion expressions between <see cref="Snowflake"/> and <see cref="long"/>.
    /// </summary>
    public SnowflakeConverter()
        : base(
            snowflake => snowflake.Value,
            value     => new Snowflake(value)) { }
}
```

**Rules:**
- Always document both conversion directions in `<remarks>` or the constructor.
- Reference where the converter is registered (`AppDbContext`) for traceability.

---

### Presentation — Controllers

**Intent:** Document the HTTP contract — status codes, request shape, and error conditions.

```csharp
/// <summary>
/// Provides API endpoints for managing registered users.
/// </summary>
/// <remarks>
/// All endpoints require a valid guild context passed via the route.
/// Soft-deleted users are excluded from all query responses.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public sealed class UsersController : ControllerBase
{
    /// <summary>
    /// Registers a new user in the system for the specified guild.
    /// </summary>
    /// <param name="command">The registration data for the new user.</param>
    /// <param name="cancellationToken">A token to observe for cancellation requests.</param>
    /// <returns>
    /// <list type="bullet">
    ///   <item><term>201 Created</term><description>The user was successfully registered. Returns the created <see cref="UserResponse"/>.</description></item>
    ///   <item><term>409 Conflict</term><description>A user with the same Discord ID and guild already exists and is active.</description></item>
    ///   <item><term>422 Unprocessable Entity</term><description>The request payload failed validation.</description></item>
    /// </list>
    /// </returns>
    [HttpPost]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> RegisterUserAsync(
        [FromBody] RegisterUserCommand command,
        CancellationToken cancellationToken = default) { }
}
```

**Rules:**
- `<returns>` must list every possible HTTP status code with its condition.
- `<remarks>` on the class must document cross-cutting concerns (auth, filters, context).
- Always pair `<returns>` documentation with `[ProducesResponseType]` attributes.

---

## Quick Reference — Summary Starters

| Member type | Starts with |
|---|---|
| Class / Struct | `Represents` / `Provides` / `Encapsulates` |
| Interface | `Defines the contract for` |
| Constructor | `Initializes a new instance of the` |
| Read-only property | `Gets` |
| Read-write property | `Gets or sets` |
| Method (action) | Verb 3rd person: `Adds`, `Returns`, `Determines`, `Removes` |
| Method (query) | `Retrieves` / `Determines whether` |
| Enum | `Defines the possible` |
| Enum member | Direct description + constraint |
| DTO | `Represents the [request/response] payload for` |
| Handler | `Handles the <see cref="XCommand"/> use case` |
| Repository | `Provides [...]-based persistence operations for` |
| Converter | `Converts a [...] to and from its [...] representation` |
| Controller | `Provides API endpoints for` |

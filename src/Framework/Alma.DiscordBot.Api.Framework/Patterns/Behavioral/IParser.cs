namespace Alma.DiscordBot.Api.Framework.Patterns.Behavioral
{
    /// <summary>
    /// Defines the contract for types that can be parsed from an external
    /// representation.
    /// </summary>
    /// <typeparam name="TInput">
    /// The type of the external representation to parse from.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// The type of the resulting instance produced by the parsing operation.
    /// </typeparam>
    /// <remarks>
    /// <para>
    /// Implementing this interface signals that a type can construct itself
    /// from an external representation via the <see cref="From"/> method.
    /// </para>
    /// <para>
    /// This interface acts as a coherence contract — it does not carry
    /// business logic and is not intended to be mocked or substituted
    /// in tests. Implementations are verified directly via their
    /// <see cref="From"/> method.
    /// </para>
    /// </remarks>
    /// <example>
    /// Implementing <see cref="IParser{TInput, TOutput}"/> on a Value Object:
    /// <code>
    /// public readonly struct RiotId : IParser&lt;string, RiotId&gt;
    /// {
    ///     public static RiotId From(string input) { ... }
    /// }
    ///
    /// // Usage
    /// RiotId riotId = RiotId.From("Faker#KR1");
    /// </code>
    /// </example>
    public interface IParser<TInput, TOutput>
        where TOutput : IParser<TInput, TOutput>
    {
        // -------------------------------------------------------------------------
        // Methods
        // -------------------------------------------------------------------------

        /// <summary>
        /// Creates a new instance of <typeparamref name="TOutput"/> from
        /// the specified <typeparamref name="TInput"/> representation.
        /// </summary>
        /// <param name="input">
        /// The external representation to parse.
        /// </param>
        /// <returns>
        /// A new instance of <typeparamref name="TOutput"/> constructed
        /// from <paramref name="input"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="input"/> does not meet the
        /// structural requirements of <typeparamref name="TOutput"/>.
        /// </exception>
        public static abstract TOutput From(TInput input);
    }
}

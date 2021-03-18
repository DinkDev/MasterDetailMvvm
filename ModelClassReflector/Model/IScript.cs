namespace ModelClassReflector.Model
{
    /// <summary>
    /// Indicates the object implements a runnable script.
    /// </summary>
    public interface IScript
    {
        /// <summary>
        /// Runs the script.
        /// </summary>
        void Run();
    }
}
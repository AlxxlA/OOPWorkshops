using System.Collections.Generic;

namespace Cosmetics.Core.Contracts
{
    interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}

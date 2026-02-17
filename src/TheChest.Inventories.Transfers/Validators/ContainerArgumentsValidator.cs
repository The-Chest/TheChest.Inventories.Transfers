using System;
using TheChest.Inventories.Containers.Interfaces;

namespace TheChest.Inventories.Transfers.Validators
{
    internal static class ContainerArgumentsValidator
    {
        /// <summary>
        /// Validates that the specified source and destination inventories are not null.
        /// </summary>
        /// <typeparam name="T">The type of items contained in the inventory.</typeparam>
        /// <param name="source">The source inventory to validate.</param>
        /// <param name="destination">The destination inventory to validate.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="destination"/> is null.</exception>
        internal static void Validate<T>(IInventory<T> source, IInventory<T> destination)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = destination ?? throw new ArgumentNullException(nameof(destination));
        }
    }
}

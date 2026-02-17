using System;
using TheChest.Inventories.Containers.Interfaces;

namespace TheChest.Inventories.Transfers.Validators
{
    /// <summary>
    /// Provides static methods for validating inventory instances and item indices before performing operations.
    /// </summary>
    internal static class ContainerIndexValidator
    {
        /// <summary>
        /// Validates that the specified inventory and index are suitable for operations.
        /// </summary>
        /// <typeparam name="T">The type of items contained in the inventory.</typeparam>
        /// <param name="inventory">The inventory to validate.</param>
        /// <param name="index">The zero-based index of the item to validate.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="inventory"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is less than 0 or greater than or equal to the size of the inventory.</exception>
        internal static void Validate<T>(IInventory<T> inventory, int index)
        {
            _ = inventory ?? throw new ArgumentNullException(nameof(inventory));
            if (index < 0 || index >= inventory.Size)
                throw new ArgumentOutOfRangeException(nameof(index), $"Index must be between 0 and {inventory.Size - 1}.");
        }
    }
}

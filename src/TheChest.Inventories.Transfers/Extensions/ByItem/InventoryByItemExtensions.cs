using System;
using TheChest.Core.Containers.Extensions;
using TheChest.Inventories.Containers.Interfaces;
using TheChest.Inventories.Transfers.Validators;

namespace TheChest.Inventories.Transfers.Extensions.ByItem
{
    /// <summary>
    /// Provides extension methods for transferring items between Inventories.
    /// </summary>
    public static class InventoryByItemExtensions
    {
        /// <summary>
        /// Transfers the specified item from the source inventory to the destination inventory.
        /// </summary>
        /// <typeparam name="T">The type of items stored in the inventories.</typeparam>
        /// <param name="source">The inventory from which the item will be transferred.</param>
        /// <param name="destination">The inventory to which the item will be transferred.</param>
        /// <param name="item">The item to transfer.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="item"/>, <paramref name="source"/> or <paramref name="destination"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> inventory does not contain the specified item or if the <paramref name="destination"/> inventory is full.</exception>
        public static void TransferTo<T>(this IInventory<T> source, IInventory<T> destination, T item)
        {
            ContainerArgumentsValidator.Validate(source, destination);
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (!source.Contains(item))
                throw new InvalidOperationException("The source inventory does not contain the specified item.");
            if (destination.IsFull)
                throw new InvalidOperationException("The destination inventory is full.");

            var itemToTransfer = source.Get(item);

            destination.Add(itemToTransfer);
        }
    }
}

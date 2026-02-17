using System;
using TheChest.Inventories.Containers.Interfaces;
using TheChest.Inventories.Transfers.Validators;

namespace TheChest.Inventories.Transfers.Extensions.FromIndex
{
    /// <summary>
    /// Provides extension methods for transferring items between inventories based on their index.
    /// </summary>
    public static class InventoryFromIndexExtensions
    {
        /// <summary>
        /// Transfers an item from the specified index in the source inventory to the destination inventory.
        /// </summary>
        /// <typeparam name="T">The type of items stored in the inventories.</typeparam>
        /// <param name="source">The inventory from which the item will be transferred.</param>
        /// <param name="index">The zero-based index of the item in the source inventory to transfer.</param>
        /// <param name="destination">The inventory to which the item will be added.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="destination"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the source slot at the specified index is empty or if the destination inventory is full.</exception>
        public static void TransferFromIndex<T>(this IInventory<T> source, int index, IInventory<T> destination)
        {
            ContainerArgumentsValidator.Validate(source, destination);
            ContainerIndexValidator.Validate(source, index);
            
            if (source[index].IsEmpty)
                throw new InvalidOperationException("The source slot is empty.");
            if (destination.IsFull)
                throw new InvalidOperationException("The destination inventory is full.");

            var item = source.Get(index);

            destination.Add(item);
        }
    }
}

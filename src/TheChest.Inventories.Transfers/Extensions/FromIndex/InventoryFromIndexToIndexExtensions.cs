using System;
using TheChest.Inventories.Containers.Interfaces;
using TheChest.Inventories.Transfers.Validators;

namespace TheChest.Inventories.Transfers.Extensions.FromIndex
{
    /// <summary>
    /// Provides extension methods for transferring items between inventories based on their indices.
    /// </summary>
    public static class InventoryFromIndexToIndexExtensions
    {
        /// <summary>
        /// Transfers an item from the specified index of the source inventory to the specified index of the destination inventory.
        /// </summary>
        /// <typeparam name="T">The type of items stored in the inventory.</typeparam>
        /// <param name="source">The source inventory from which the item will be transferred.</param>
        /// <param name="sourceIndex">The zero-based index of the item in the source inventory to transfer.</param>
        /// <param name="destination">The destination inventory to which the item will be transferred.</param>
        /// <param name="destinationIndex">The zero-based index in the destination inventory where the item will be placed.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="destination"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="sourceIndex"/> or <paramref name="destinationIndex"/> is less than 0 or greater than or equal to the size of the inventory.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the source slot is empty or if the destination slot is full.</exception>
        public static void TransferFromIndex<T>(
            this IInventory<T> source, int sourceIndex, 
            IInventory<T> destination, int destinationIndex
        )
        {
            ContainerArgumentsValidator.Validate(source, destination);

            ContainerIndexValidator.Validate(source, sourceIndex);
            ContainerIndexValidator.Validate(destination, destinationIndex);

            if (source[sourceIndex].IsEmpty)
                throw new InvalidOperationException("The source slot is empty.");
            if (destination[destinationIndex].IsFull)
                throw new InvalidOperationException("The destination slot is full.");

            var item = source.Get(sourceIndex);

            destination.AddAt(item, destinationIndex);
        }
    }
}

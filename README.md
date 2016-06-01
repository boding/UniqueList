# UniqueList
UniqueList with C#
I thought this will be much more fast than the List container, but when I ran with 500 items, the difference is not explicit. The Dictionary and GetHashCode may be the bottleneck. Also I found that List.Contains/Remove is a binarysearch and not slow as I thought. Finally I perfered List container in my program.

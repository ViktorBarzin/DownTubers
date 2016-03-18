using System;

namespace Interfaces
{
	public interface IVideoSearchResult
	{
		int Id { get; }
		Uri ThumbnailSource { get; }
		string Title { get; }
		string Description { get; }
	}
}

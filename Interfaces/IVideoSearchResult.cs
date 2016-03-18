using System;

namespace Interfaces
{
	public interface IVideoSearchResult
	{
		Uri ThumbnailSource { get; }
		string Title { get; }
		string Description { get; }
	}
}

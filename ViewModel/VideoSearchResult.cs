using System;
using Interfaces;

namespace ViewModel
{
	using System.ComponentModel;

	using DatabaseLayer;

	public class VideoSearchResult : IVideoSearchResult
	{
		public int Id { get; }

		public Uri ThumbnailSource { get; }

		public string Title { get; }

		public string Description { get; }

		public VideoSearchResult(VideoSet video)
		{
			ThumbnailSource = new Uri(@"http://images.mentalfloss.com/sites/default/files/styles/insert_main_wide_image/public/einstein1_7.jpg");

			Id = video.Id;
			Title = video.Title;
			Description = video.Description;
		}
	}
}

namespace DotnetModularApp.Options
{
	public class MergePdfOptions
	{
		public const string MergePdf = "MergePdf";

		public int MaxFilesAllowed { get; set; }

		public long MaxSizeAllowed { get; set; }
	}
}
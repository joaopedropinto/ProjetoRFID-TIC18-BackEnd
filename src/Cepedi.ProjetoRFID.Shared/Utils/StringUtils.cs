using System.Globalization;
using System.Text;

namespace Cepedi.ProjetoRFID.Shared.Utils
{
	public static class StringUtils
	{
		public static bool AreNamesEqual(string name1, string name2)
		{
			string normalized1 = RemoveDiacritics(name1.ToUpper());
			string normalized2 = RemoveDiacritics(name2.ToUpper());

			return string.Equals(normalized1, normalized2, StringComparison.OrdinalIgnoreCase);
		}

		public static string RemoveDiacritics(string text)
		{
			var normalizedString = text.Normalize(NormalizationForm.FormD);
			var stringBuilder = new StringBuilder();

			foreach (var c in normalizedString)
			{
				var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
				if (unicodeCategory != UnicodeCategory.NonSpacingMark)
				{
					stringBuilder.Append(c);
				}
			}

			return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
		}
	}
}

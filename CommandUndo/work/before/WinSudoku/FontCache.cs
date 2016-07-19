using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WinSudoku
{
    public class FontCache : IDisposable
    {
        Dictionary<FontStyle, Dictionary<int, Font>> cache = new Dictionary<FontStyle, Dictionary<int, Font>>();

        public void AddFont(Font font,int textLength)
        {
            if ( cache.ContainsKey(font.Style) == false )
            {
                cache[font.Style] = new Dictionary<int,Font>();
            }

            cache[font.Style][textLength] = font;
        }

        public Font GetFont(FontStyle style, int textLength)
        {
            if (cache.ContainsKey(style))
            {

                if (cache[style].ContainsKey(textLength))
                {
                    return cache[style][textLength];
                }
            }

            return null;
        }


        #region IDisposable Members

        public void Dispose()
        {
            foreach (Dictionary<int, Font> fontCacheRow in cache.Values)
            {
                foreach (Font font in fontCacheRow.Values)
                {
                    font.Dispose();
                }

                fontCacheRow.Clear();
            }

            cache.Clear();
        }

        #endregion
    }
}

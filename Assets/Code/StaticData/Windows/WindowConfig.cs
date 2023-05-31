using System;
using UI;
using UI.Services.Windows;

namespace StaticData.Windows
{
  [Serializable]
  public class WindowConfig
  {
    public WindowId WindowId;
    public WindowBase Template;
  }
}
using System;
using AdBuddiz.Xamarin;

namespace AdBuddiz.Xamarin
{
   public class AdBuddizErrorEventArgs: EventArgs
   {
      public readonly string ErrorDescription;
      public readonly AdBuddizError Error;

      public AdBuddizErrorEventArgs(AdBuddizError error)
      {
         ErrorDescription = AdBuddizHandler.Instance.NameForError(error);
         Error = error;
      }
   }
}


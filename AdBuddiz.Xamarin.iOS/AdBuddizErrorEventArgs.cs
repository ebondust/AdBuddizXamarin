using System;
using AdBuddiz.Xamarin.Ios;

namespace AdBuddiz.Xamarin.Ios
{
   public class AdBuddizErrorEventArgs: EventArgs
   {
      public readonly String ErrorDescription;
      public readonly AdBuddizError Error;

      public AdBuddizErrorEventArgs(AdBuddizError error)
      {
         String nameForError = AdBuddiz.Xamarin.Ios.Internal.AdBuddiz.NameForError(error);
         ErrorDescription = nameForError;
         Error = error;
      }
   }
}


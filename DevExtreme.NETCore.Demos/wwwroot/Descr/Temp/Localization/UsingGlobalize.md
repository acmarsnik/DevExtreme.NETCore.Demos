DevExtreme ASP.NET MVC Controls can be localized by means of Globalize. Globalize modules and CLDR scripts are already added to your project along with other resources for DevExtreme ASP.NET MVC Controls. Do the following to use them:  

1. In your controller, create an action method that loads CLDR data for desired locales. See the **CldrData()** action method in LocalizationController.cs.
2. Create a section on the view with DevExtreme ASP.NET MVC Controls to localize and call the action method from it. In the same section, link DevExtreme dictionaries for the desired locales. See the **Localization** section in UsingGlobalize.cshtml.
3. Add the following command to the <head\> tag of the shared layout view. The view is not shown in this demo.  

    `@RenderSection('Localization', false)`

4. Set the current locale using the **Globalize.locale** method. See the <script\> tag in UsingGlobalize.cshtml.
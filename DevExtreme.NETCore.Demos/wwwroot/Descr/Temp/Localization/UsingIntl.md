DevExtreme ASP.NET MVC Controls can be localized by means of the [Intl][0] object. Do the following to use it:  

1. Create a section on the view with DevExtreme ASP.NET MVC Controls to localize, and link the devextreme-intl module and DevExtreme dictionaries for desired locales there. See the **Localization** section in UsingIntl.cshtml.
2. Add the following command to the <head\> tag of the shared layout view. The view is not shown in this demo. 

    `@RenderSection('Localization', false)`
	
3. Set the current locale using the **DevExpress.localization.locale** method. See the <script\> tag in UsingIntl.cshtml.

[0]: https://developer.mozilla.org/en/docs/Web/JavaScript/Reference/Global_Objects/Intl
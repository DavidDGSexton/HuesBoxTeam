# HuesBox Color Picker App
#### Aubri Stahl, David Windsor, David Sexton, Phillip Gomez

### Home Page
The landing page offers two buttons.  The “Select Color” button directs user to the Select Color page.  The “Contact Us” button directs user to the contact form.  The user may select the button or the icon to go to their corresponding pages.

### Select Color Page
This page allows the user to select a color by either entering a hex value or by using the red, green, and blue (RGB) sliders together to select a color. All values on this page are defaulted to white (#FFFFFF) until the user changes the values. The selected color is shown at the top of the page in the color box preview as a visible color and in the entry field as a hex code. Color changes are seen instantly with user-input into either the entry field or 3-slider RGB control and will display the color on input change, assuming the entry is valid. 

The first control is the hexcode entry field. The user can tap on the entry field and enter the hex value of a color. That color will display in the color box above as long as it is a valid hexcode, with or without the hash at the beginning. There is input validation to prevent a crash from processing strings that aren't hexcodes. The string gets trimmed as well, so beginning/end spaces shouldn't be a problem.

The RGB sliders can also be used to select a color. With each slider, you can choose between a range of intergers from 0 to 255. As soon as any of the slider values are changed, the code behind takes the numerical value from each of the three sliders and converts each one individually into a hexadecimal. Once the three hexadecimals for each color are found, the entry field will update it's string to display the hash symbol followed by the RGB hexadecimals placed together in order to form a hexcode.

A third option to select a color is to click on the camera icon below the sliders, which will take you to the camera page, which will be detailed below. Once a color is found by the user, they will be taken back to the select color page with their new color being set as the preview color. 

The submit button at the bottom of the page will lead to the results page.

### Results Page
After selecting a color, the user is taken to the results page. At the top of the page is the color the user selected along with the hex code. Below that is a list of complimentary colors and their respective hex values. Each complimentary color is calculated slightly different to give the user multiple options. The first color is on the opposite side of the color wheel. This is calculated by taking the selected color’s red, blue, and green values and subtracting 255 from each, then converting that into a hex value to give the complementary color. The second color is found by converting the selected color values from Red, Green, and Blue to Hue, Saturation, and Light. Then, 180 is subtracted from the Hue value, which moves it to the opposite side of the color wheel, giving it a complimentary color. The HSL values are then converted back to RGB and then to Hex Values to display the color and hex value. At the bottom of this page is an export button. This will move the user to the export form.

Reference for converting RGB to HSL:
https://serennu.com/colour/rgbtohsl.php

### Camera Page
Currently through the use of the Xam.Plugin.Media NuGet package, the app has the ability to request permission to use the phone's camera to take pictures of something that a user might want the color of. When the picture is taken, it is loaded into an image box on screen with a set width and height to avoid crashing from larger images. While the camera works fine, there is some trouble with grabbing the color from the image, which makes this a feature that is unlikely to make it into the finished app.

### Export Form
This form is used to export the information from the results page to an email and send it to the user. The form will simply ask for the user’s email address. Once input, the user taps the submit button and an email will be sent to that address. The email will contain the information from the results page, which is the selected color along with all the complimentary colors and respective hex values.

### Contact Page
Here we have a field for name and email entry, an editor for the body of the email, and a button to ask the device to load a mail app to copy the email into. The recipients of the email are set in the code behind by being added as a string list. Note that you might want to use an email address that isn't your main, since they will be able to see it in their email client. The email function is setup using the NuGet package 'Xamarin.Essentials'. Its email task uses only the three variables for subject, body, and recipients. The subject consists of a combination of the Name and Email entry to for the following subject: HBContact :Name - Email.

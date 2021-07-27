# Lightification - A notification scheduler for Philips Hue Lightbulbs

#### By _**John Edmondson**_

### Epicodus Capstone Project for the March 2021 Co-hort

A well-designed app to provide a user with the ability to get an event notification in a minimally obtrusive way by subtly changing the light's output.

## MVP Features

- A beautifully styled site that has a straightforward user experience.
- User authentication
- Connect your Phillips hue account to the app
- Create a scheduled in app event to send a notification to the user's light.

## Future Features

- Connect the service to a consistently updated notification source
  - Connect the app to an RSS feed API to notify the user whenever a feed is updated. There are some API's that allow you to create an RSS feed on just about any URL type (i.e., youtube channel, Twitter profile, Twitter hashtag, podcast feed, blog page, social comments)
  - Connect the app to Google Calendar (which can be integrated into just about any other calendar app) that can then be set in the app to a particular event type. Then your interaction with the app would be less and integrated into your normal workflow of scheduling.
- Create multiple preset options for the light notifications.
  - First Priority: Adjust the brightness from low to high to then in 5s, 10s, 30s, 1m loops.
- Handle multiple notifications types.
  - If it's a color bulb, then cycle through multiple colors slowly, with each color corresponding to each type.
  - If it's only a white bulb, then potentially have a flash system
  - If the user has multiple bulbs, then the user can assign different notification types to individual bulbs
- BIO / FAQ / Help section
  - Mission Statement
  - Examples of different types of sites you can link into the notification service.
  - Give tutorials on how to connect 3rd party services to your google calendar.

## Project References

- [Hue Get Started Guide](https://developers.meethue.com/develop/get-started-2/)
- [Hue API](https://developers.meethue.com/develop/hue-api/)
- [Hue Hacking by Bryan Johnson](https://github.com/bjohnso5/hue-hacking)
- [React and Google OAuth with .NET Core backend by Atul Shukla](https://medium.com/mickeysden/react-and-google-oauth-with-net-core-backend-4faaba25ead0)

  ## Tech Stacks

  Javascript, HTML, CSS, React, Firebase, and Philips Hue API

## Run Locally

Clone the project

```bash
  git clone https://github.com/basicjohn/tap-room.git
```

Go to the project directory

```bash
  cd my-project
```

Install dependencies

```bash
  npm install
```

Start the server

```bash
  npm run start
```

## Diagram

![React Project Diagram](diagram.png)

## Author

- [@BasicJohn](https://www.github.com/basicjohn)

## License

[MIT](https://choosealicense.com/licenses/mit/)

a

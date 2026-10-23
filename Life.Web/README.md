# LifeWeb

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 22.2.1.

## API

The frontend expects the .NET API to be available under `/api` with these endpoints:

- `POST /api/auth/login` and `POST /api/auth/register` with `{ "email", "password", "name?" }`.
- `GET /api/homeworks` returning an array of homework items.
- `POST /api/homeworks` with `{ "title", "description", "dueDate" }`.

Authentication responses may return `token` or `accessToken`; the frontend sends it as a Bearer token. Change `API_BASE_URL` in `src/app/services/api.ts` or configure a development proxy if your API uses another host. The API must allow the frontend origin through CORS when the frontend and API are hosted separately.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Vitest](https://vitest.dev/) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.

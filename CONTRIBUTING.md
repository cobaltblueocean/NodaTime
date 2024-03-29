# How to Contribute

Thanks for your interest in Noda Time. We appreciate all kinds of contributions, from submitting issues to improving documentation; from writing tests to implementing new code. All help is welcome!

## Basic Requirements

If you want to contribute to the codebase, you're going to need a text editor or IDE. We recommend [Visual Studio Community](https://visualstudio.microsoft.com/downloads/) (Windows) or [Visual Studio Code](https://code.visualstudio.com/) (Windows/Linux/macOS).

[Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) and [JetBrains Rider](https://www.jetbrains.com/rider/) should be fine as well, but we haven't tried developing Noda Time using them.

You're also going to need the .NET / .NET Core SDK installed. Look at the [global.json](global.json) file to see which version of the SDK is currently required, then download it from [here](https://dotnet.microsoft.com/download). (The version required to build and test Noda Time won't always be the most recent version; we generally stick to LTS releases unless there's a compelling reason to upgrade to something else.)

Please make sure you have a [git client](https://git-scm.com/) installed. If you don't already have a GitHub account, [please create one](https://github.com/join).

After you're all set, you can [fork the project](https://help.github.com/articles/fork-a-repo). Then you'll be able to clone your fork, so you can edit the files locally on your machine:

```Text
git clone https://github.com/YOUR-USERNAME/nodatime.git
```

Once you clone the repository, you'll have a [remote repository](https://git-scm.com/book/en/v2/Git-Basics-Working-with-Remotes) (or simply *remote*) called `origin`, that points to your forked repository on GitHub.

You'll usually want to add another remote, pointing to the original repository on GitHub. It's an accepted convention to call this remote *upstream*. You can do it like this:

```Text
git remote add upstream https://github.com/nodatime/nodatime.git
```

## How to start contributing?

We have a [`help-wanted`](https://github.com/nodatime/nodatime/labels/help%20wanted)
label on our issue tracker to indicate tasks which new contributors can work on without much previous experience in Noda Time.

If you've found something you'd like to help with, please leave a comment in the issue.

Additionally, feel free to open an issue if you find a bug or want to suggest a feature or enhancement.

### Making Changes

When you're ready to start working, create a new branch off the `main` branch:

```
git checkout main
git pull upstream main
git checkout -b SOME-BRANCH-NAME
```

Try to use a short, descriptive name for your branch, such as `add-tests-foobar-struct`.

### Building

To build everything under Visual Studio, simply open the src/NodaTime.sln solution file and build normally. To build with just the .NET Core SDK, run

```Text 
dotnet build src/NodaTime.sln
```

### Running Tests

Simply run the following command:

```Text
dotnet test src/NodaTime.Test
```

### Submitting Changes

To publish your branch to your local fork, run this command from the Git Shell:

```Text
git push origin -u MY-BRANCH-NAME
```

When your work is finished, [open a pull request](https://help.github.com/articles/using-pull-requests) against your changes.

If your pull request fixes an issue, add a comment with the word "Fixes", "Resolves" or "Closes", followed by the issue's number:

>   Fixes #1145

If you need to, feel free to add comments to the PR asking for suggestions or help.

### Bash scripts

### Other scripts

Bash scripts are used for more complex tasks such as updating TZDB. Many contributors will never need to run these scripts, but just occasionally they may be useful when investigating a CI failure.

These should largely work from any bash environment, but the one used by the maintainers is the version included with [Git for Windows](https://git-scm.com/download/win), also sometimes known as "git bash". Please [file an issue](https://github.com/nodatime/nodatime/issues/new) if you need to run a script but have trouble doing so.

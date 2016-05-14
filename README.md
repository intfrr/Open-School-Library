#Open School Library
An Open Source Library Management Tool Geared Towards Schools.

>**This project is in pre-release.**

##Developer's Notes

This project uses the [Git Flow model](http://nvie.com/posts/a-successful-git-branching-model/).

The master branch will only contain releases and updated README and related files going forward. (Though we have not yet released a working application)

The devlop branch will only contain code that is currently being worked on.

Feature branches will sporadically appear and disappear like whales and flower pots in the sky as needed. When a feature branch is finished it will be merged with the devlop branch then deleted.

## Contributing

### Coding style

1. Always use tabs. 
2. Always place braces on new lines.
3. Use [C# 6](https://github.com/dotnet/roslyn/wiki/New-Language-Features-in-C%23-6) whenever possible. 
4. Follow the [standard MS C# naming conventions](https://msdn.microsoft.com/en-us/library/ms229002(v=vs.110).aspx) 
([short version](http://programmers.stackexchange.com/a/224910)). 
Also see: [How to name things in programming](http://www.slideshare.net/pirhilton/how-to-name-things-the-hardest-problem-in-programming)
5. Know when to make exceptions.

### Commits and Pull Requests

Keep the commit log as healthy as the code. It is one of the first places new contributors will look at the project.

1. No more than one change per commit. There should be no changes in a commit which are unrelated to its message.
2. Follow [these conventions](http://chris.beams.io/posts/git-commit/) when writing the commit message.

When filing a Pull Request, make sure it is rebased on top of most recent master.
If you need to modify it or amend it in some way, you should always appropriately 
[fixup](https://help.github.com/articles/about-git-rebase/) the issues in git and force-push your changes to your fork.

Also see: [Github Help: Using Pull Requests](https://help.github.com/articles/using-pull-requests/)

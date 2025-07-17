[![MseeP.ai Security Assessment Badge](https://mseep.net/pr/nisalgunawardhana-how-to-create-mcp-server-badge.png)](https://mseep.ai/app/nisalgunawardhana-how-to-create-mcp-server)

# How to Create MCP Server Using .NET

This guide will help you set up a basic MCP (Model Context Protocol) server in .NET, configure it in VS Code, and interact with it using Copilot Chat.

[![Follow me on GitHub](https://img.shields.io/github/followers/nisalgunawardhana?label=Follow%20me%20on%20GitHub&style=social)](https://github.com/nisalgunawardhana)


## How to Clone This Repo and Start Working

1. **Fork this repository** to your own GitHub account.
2. **Clone your fork** to your local machine:
    ```zsh
    git clone https://github.com/<your-username>/How-To-Create-MCP-Server
    cd How-To-Create-MCP-Server
    ```
    > **Note:** Replace `<your-username>` with your actual GitHub username in the clone URL above.
3. **Create a new branch** for your changes (for example, `feature/my-contribution`):
    ```zsh
    git checkout -b feature/my-contribution
    ```

    > <span style="background-color:#ffdddd; padding:2px 6px; border-radius:4px;">🛑 **Already completed steps 1–3?**</span>  
    > If you've already forked, cloned, and created your branch, you can skip ahead to [🚀 Start Work Now](#-start-work-now) and continue with the rest of the setup!
    
4. **Make your changes** and commit them.
    ```zsh
    git add .
    git commit -m"my-contribution"
    ```
5. **Push your branch** to your fork:
    ```zsh
    git push origin feature/my-contribution
    ```
    Once you've pushed your changes, go to your GitHub repository in your browser. Switch to the `feature/my-contribution` branch

![Add Tool in Copilot Chat](images/image3.png)

        
6. **Open a Pull Request (PR)** from your branch to the `Submit` branch of this repository (not `main`).

**Step 01**
![Add Tool in Copilot Chat](images/image4.png)
**Step 02**
![Add Tool in Copilot Chat](images/image5.png)

> **Note:** Please do **not** open PRs directly to the `main` branch. Always target the `Submit` branch for contributions.
**Follow the steps below to set up and run the MCP server.**

---

## 🚀 Start Work Now

Ready to dive in?  
After cloning and setting up your branch, you can immediately begin making changes or adding features to the MCP server project. Use the provided steps below to guide your development process. If you get stuck, refer to the resources and discussion links at the end of this guide.

---

## 1. Install .NET

Download and install the [.NET SDK](https://dotnet.microsoft.com/download) for your OS.
> **Note:** This guide uses **.NET SDK 8**. Make sure you download the correct version for your operating system.

If you're using **VS Code**, install the [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) for the best development experience.

Verify installation in your terminal:
```zsh
dotnet --version
```

---

## 2. Create a New Project

Open your terminal and run:
```zsh
dotnet new console -o HelloSriLankaServer
cd HelloSriLankaServer
```

---

## 3. Install Required Packages

Install the necessary NuGet packages:

```zsh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting 
```


---
## Project Folder Structure

After creating the project, your folder structure should look like this:

```text
How-To-create-MCP-Server/
├── HelloSriLankaServer/
│   ├── Program.cs
│   ├── HelloSriLankaServer.csproj
│   └── (other project files)
├── images/
│   ├── image1.png
│   └── image2.png
├── README.md
└── LICENSE
```

This structure helps keep your source code, configuration, and documentation organized.

---

## 4. Update `Program.cs`

Clear the contents of `Program.cs` and replace with:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddConsole(options => {
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

Console.WriteLine(builder.Environment.ContentRootPath);
var app = builder.Build();

await app.RunAsync();

[McpServerToolType]
public static class HelloTool
{
    [McpServerTool(Name = "HelloTool"), Description("Say hello to Sri Lanka")]
    public static void SayHello()
    {
        Console.WriteLine("Hello Sri Lanka!");
        
    }
}
```

---

## 5. Configure MCP in VS Code

1. In your project root, create a `.vscode` directory:

  Before creating the `.vscode` directory, navigate back to the project root if you're inside the `HelloSriLankaServer` folder:

  ```zsh
  cd ..
  ```

  ```zsh
  mkdir -p .vscode
  ```

  After creating the `.vscode` directory, your folder structure should look like this:

  ```text
  How-To-create-MCP-Server/
  ├── HelloSriLankaServer/
  │   ├── Program.cs
  │   ├── HelloSriLankaServer.csproj
  │   └── (other project files)
  ├── images/
  │   ├── image1.png
  │   └── image2.png
  ├── .vscode/
  ├── README.md
  └── LICENSE
  ```

2. Inside `.vscode`, create a file named `mcp.json` and add your server configuration.

    - Once created, you will see an **Add Server** button. Click it.  
      ![Add Server Button](images/image6.png)

    - Choose **"Command (stdio)"** as the server type.  
      ![Choose Command (stdio)](images/image7.png)

    - Enter `"dotnet"` as the command and press Enter.  
      ![Enter dotnet](images/image8.png)

    - Enter the server name `"Hello-SriLankaServer"` and press Enter.  
      ![Enter Server Name](images/image9.png)

    - The `mcp.json` file will be populated automatically. Replace missing contents with the following:

      ```json
      {
        "servers": {
          "Hello-SriLankaServer": {
            "type": "stdio",
            "command": "dotnet",
            "args": [
              "run",
              "--project",
              "${workspaceFolder}/HelloSriLankaServer/HelloSriLankaServer.csproj"
            ]
          }
        }
      }
      ```
   
      > **Note:** `${workspaceFolder}` will automatically resolve to your project root. If it does not work, replace it with the actual path to your `.csproj` file (right-click the file in VS Code and select "Copy Path").

## 6. Run the MCP Server(test if it's work)

From the `HelloSriLankaServer` directory, start the server:
```zsh
dotnet run
```
> **Note:** Once you've confirmed the server is running successfully, you can stop it (press `Ctrl+C` in the terminal) and proceed to the next step (Step 7).
---

## 7. Add the Tool in Copilot Chat

> **Note:** Before adding the tool in Copilot Chat, make sure your MCP server is running. Then, open the `mcp.json` file in VS Code. You will see a small **"Add Tool"** button appear just below the(2nd Line) `"servers": {` line in the JSON code—click this button to proceed.

1. Open Copilot Chat in VS Code.
2. Click the **gear icon** (⚙️) or the **"Add Tool"** button.
3. Select your MCP server (`Hello-SriLankaServe`) from the list.

**Image Example:**
> **Note:** The example images may display "LocationServer" or a similar name, but it actually refers to your MCP server (`Hello-SriLankaServer`).
![Add Tool in Copilot Chat](images/image1.png)
![Add Tool in Copilot Chat](images/image2.png)


---

## 8. Send a Message Using Copilot Chat

1. In Copilot Chat, select the `Hello-SriLankaServer` tool.
2. Type a message to invoke your tool, for example:
    ```
    Can you Say hello to Sri Lank
    ```
    > **Note:** You may need to grant permission or continue when prompted by VS Code. Sometimes, Copilot Chat or other AI tools do not have access to the terminal or workspace by default. If you see a prompt asking for access, make sure to allow it so your tool can run successfully.

3. You should see a reply from your MCP server in the chat.
    ```
    Hello Sri Lanka !
    
    ```

---

## 9. Get a Reply from the MCP Server

You will receive a response from your MCP server in the Copilot Chat window.

---

## 10. Advanced Demo: Try the MCP Location Server

For a more advanced example, you can explore the [Try-mcp-location-server-demo](https://github.com/nisalgunawardhana/Try-mcp-location-server-demo) repository. This demo showcases how to build and interact with a location-based MCP server using .NET.

---
## 🎁 Share and Win Amazing Tech Swag!

Love this project? Share it with your friends and community for a chance to win exclusive tech swag!

- **How to participate:**  
  Fill out [this form](https://forms.gle/eGxg1bAZgqwq6mPw7) to request your personalized share link. We'll send your unique link to your email within 2–3 business days.

- **Share and Win:**  
  Once you receive your link, share it with your friends. Ask them to complete the project and include your referral link when they submit.

- **Why share?**  
  The more friends who use your referral link, the higher your chances to win cool tech goodies—stickers, shirts, and more!

> **Note:** Make sure your email is visible in your GitHub profile or mention it in the form when you request your link.

Stay tuned—winners will be announced in the Discussions tab!


## Additional Learning Resources

For a deeper understanding of MCP and more hands-on examples, check out the [Introduction to MCP](https://github.com/nisalgunawardhana/introduction-to-mcp) repository. This resource provides tutorials, sample projects, and further guidance on working with MCP in .NET.

---

## 💬 Join the Discussion!

Have questions, ideas, or want to share your experience?  
We welcome you to use [GitHub Discussions](https://github.com/nisalgunawardhana/How-To-create-MCP-Server/discussions) for:

- Asking questions about setup or usage
- Sharing feedback or suggestions
- Requesting new features
- Connecting with other contributors

👉 **Click the "Discussions" tab at the top of this repo to start or join a conversation!**

Let's build and learn together!

---

## Connect with Me

Follow me on social media for more sessions, tech tips, and giveaways:

- [LinkedIn](https://www.linkedin.com/in/nisalgunawardhana/) — Professional updates and networking
- [Twitter (X)](https://x.com/thenisals) — Insights and announcements
- [Instagram](https://www.instagram.com/thenisals) — Behind-the-scenes and daily tips
- [GitHub](https://github.com/nisalgunawardhana) — Repositories and project updates
- [YouTube](https://www.youtube.com/channel/UCNP5-zR4mN6zkiJ9pVCM-1w) — Video tutorials and sessions

Feel free to connect and stay updated!

---

## License

This project is licensed under the [MIT License](LICENSE).

---

**Tip:**  
You can add more tools to your MCP server by extending the `HelloTool` class in `Program.cs`.

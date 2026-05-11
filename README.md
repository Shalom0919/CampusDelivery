# 校园中转分发与跑腿服务管理系统

基于 Vue 3 + .NET 8 Web API + Oracle 18c 构建的前后端分离企业级/校园级服务系统。

## 🛠 技术栈

### 前端 (Frontend)
- **核心框架**: Vue 3 (Composition API)
- **构建工具**: Vite
- **UI 组件库**: Element Plus
- **路由与状态**: Vue Router 4 + Pinia
- **网络请求**: Axios

### 后端 (Backend)
- **核心框架**: ASP.NET Core 8.0 Web API
- **数据库**: Oracle Database 18c
- **ORM 框架**: Dapper (轻量级高性能数据映射)
- **鉴权**: JWT (JSON Web Token) 无状态认证

---

## 📂 目录结构

本仓库采用 Monorepo 模式，前后端代码物理隔离：

```text
├── frontend/             # 前端 Vue 3 工程目录
├── backend/              # 后端 .NET 8 Web API 工程目录
├── .gitignore            # 全局忽略配置文件
└── README.md             # 项目说明文档

🚀 快速启动指南

1. 环境准备

Node.js: v18.0 或以上版本 (用于运行前端)

.NET SDK: 8.0 版本 (用于运行后端)

数据库: 本地或远程的 Oracle 18c 实例

2. 数据库初始化

使用 SQL Developer / Navicat 等工具连接至 Oracle 数据库。

运行 backend/Scripts/ (如有) 目录下的 SQL DDL 脚本，初始化 user_account、task_order 等核心表。

3. 后端服务启动

使用 Visual Studio 2022 打开 backend/TaskSystem.Api.sln。

打开 appsettings.json，修改 Oracle 数据库连接字符串：

JSON



"ConnectionStrings": {

  "OracleDb": "User Id=your_username;Password=your_password;Data Source=localhost:1521/ORCL;"

}

按下 F5 或点击顶部运行按钮启动服务。

默认启动地址：https://localhost:7097 (会自动打开 Swagger API 接口文档)。

4. 前端服务启动

打开命令行，进入前端目录：

Bash



cd frontend

安装依赖：

Bash



npm install

检查 src/utils/request.ts 中的 baseURL 是否与后端启动的端口一致。

启动开发服务器：

Bash



npm run dev

浏览器访问：http://localhost:5173。

👨‍💻 团队协作规范

分支命名规范

请统一在 dev 分支拉取新分支进行开发，严禁直接在 main 或 dev 上 Push 代码！

前端功能：feat/fe-xxx (例：feat/fe-login-view)

后端功能：feat/be-xxx (例：feat/be-auth-api)

缺陷修复：fix/fe-xxx 或 fix/be-xxx

Commit 提交规范

提交信息需清晰表明修改意图，建议采用以下格式：

feat(fe/be): 新增xxx功能

fix(fe/be): 修复xxx缺陷

docs: 更新文档

style: 调整代码格式/UI样式

Pull Request (PR) 流程

在本地完成开发并测试通过后，Push 分支到 GitHub。

提交 PR，目标分支（Base）必须设置为 dev。

确保无冲突，经过简要 Review 后执行 Merge。
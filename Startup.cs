<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Pipeline-Projeto</title>
    <script src="https://cdn.tailwindcss.com"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.6.0/css/all.min.css">
    
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600&display=swap');

        body {
            font-family: 'Inter', "Segoe UI", Arial, sans-serif;
            background: #0b1420;
            color: #e6edf3;
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 20px;
        }

        .pipeline-container {
            background: #161b22;
            border-radius: 16px;
            padding: 32px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.5);
            max-width: 1200px;
            width: 100%;
        }

        /* Box Style */
        .stage-box {
            width: 400px;
            background: #161b22;
            border-radius: 8px;
            border: 1px solid #30363d;
            position: relative;
            padding: 16px;
            box-shadow: 0 0 0 1px rgba(46,160,67,0.2);
            opacity: 0;
            transform: translateY(60px);
        }

        .stage-box.visible {
            animation: fadeSlide 1.2s ease forwards;
        }

        .stage-box::before {
            content: "";
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 4px;
            background: #2ea043;
            border-top-left-radius: 8px;
            border-top-right-radius: 8px;
        }

        .header {
            display: flex;
            align-items: center;
            gap: 8px;
            font-weight: 600;
            margin-bottom: 6px;
        }

        .check {
            width: 16px;
            height: 16px;
            background: #2ea043;
            border-radius: 50%;
            display: inline-block;
            position: relative;
        }

        .check::after {
            content: "✓";
            position: absolute;
            color: #fff;
            font-size: 12px;
            top: 0;
            left: 4px;
        }

        .pipeline-id {
            color: #58a6ff;
            font-size: 12px;
            margin-bottom: 6px;
            word-break: break-word;
            background: #0d1117;
            padding: 8px;
            border-radius: 4px;
            border: 1px solid #30363d;
        }

        .status {
            font-size: 13px;
            margin-bottom: 12px;
            color: #8b949e;
        }

        .inner {
            border: 1px solid #30363d;
            border-radius: 6px;
            background: #0d1117;
            padding: 8px 12px;
            margin-bottom: 8px;
            font-size: 13px;
        }

        .inner .label {
            display: flex;
            align-items: center;
            gap: 6px;
            margin-bottom: 4px;
            color: #8b949e;
        }

        .inner .label .check {
            width: 14px;
            height: 14px;
        }

        .inner .service {
            color: #58a6ff;
        }

        .inner .time {
            font-size: 12px;
            color: #8b949e;
        }

        /* Arrow */
        .arrow {
            width: 60px;
            height: 3px;
            background: #2ea043;
            position: relative;
            top: 30px;
        }

        .arrow::after {
            content: "";
            position: absolute;
            right: -10px;
            top: -6px;
            border-left: 12px solid #2ea043;
            border-top: 8px solid transparent;
            border-bottom: 8px solid transparent;
        }

        @keyframes fadeSlide {
            to {
                opacity: 1;
                transform: translateY(0);
            }
        }

        .top-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 35px;
        }

        h1.welcome {
            text-align: center;
            font-size: 2.2rem;
            margin-top: 50px;
            color: #c9d1d9;
        }
    </style>
</head>
<body>

    <div class="pipeline-container">
        <!-- Top Header -->
        <div class="top-header">
            <div class="flex items-center gap-4">
                <h1 class="text-3xl font-semibold">Pipeline-Projeto</h1>
                <div class="flex items-center gap-2 text-emerald-400 text-sm">
                    <span class="w-3 h-3 bg-emerald-400 rounded-full animate-pulse"></span>
                    Concluído com sucesso
                </div>
            </div>
            
            <div class="flex gap-3">
                <button id="rebuildBtn" 
                        class="px-5 py-2 bg-gray-800 hover:bg-gray-700 rounded-xl text-sm flex items-center gap-2 transition">
                    <i class="fas fa-redo"></i> 
                    Rebuild
                </button>
                <button class="px-6 py-2 bg-red-600 hover:bg-red-500 rounded-xl text-sm flex items-center gap-2 transition">
                    <i class="fas fa-stop"></i> 
                    Stop Build
                </button>
            </div>
        </div>

        <!-- Pipeline -->
        <div class="flex items-center justify-center gap-8">
            
            <!-- SOURCE -->
            <div id="source" class="stage-box">
                <div class="header">
                    <span class="check"></span>
                    <span>Source</span>
                </div>
                <div class="pipeline-id">
                    a6b37c6c-a52f-4344-80db-fe2e96d20f42
                </div>
                <div class="status">All actions succeeded.</div>
                
                <div class="inner">
                    <div class="label">
                        <span class="check"></span>
                        Source
                    </div>
                    <div class="service">GitHub (via GitHub App)</div>
                    <div class="time">9 minutes ago</div>
                </div>
            </div>

            <div class="arrow"></div>

            <!-- BUILD -->
            <div id="build" class="stage-box">
                <div class="header">
                    <span class="check"></span>
                    <span>Build</span>
                </div>
                <div class="pipeline-id">
                    a6b37c6c-a52f-4344-80db-fe2e96d20f42
                </div>
                <div class="status">All actions succeeded.</div>
                
                <div class="inner">
                    <div class="label">
                        <span class="check"></span>
                        Build
                    </div>
                    <div class="service">AWS CodeBuild</div>
                    <div class="time">8 minutes ago</div>
                </div>
            </div>

            <div class="arrow"></div>

            <!-- DEPLOY -->
            <div id="deploy" class="stage-box">
                <div class="header">
                    <span class="check"></span>
                    <span>Deploy</span>
                </div>
                <div class="pipeline-id">
                    a6b37c6c-a52f-4344-80db-fe2e96d20f42
                </div>
                <div class="status">All actions succeeded.</div>
                
                <div class="inner">
                    <div class="label">
                        <span class="check"></span>
                        Deploy
                    </div>
                    <div class="service">Amazon ECS</div>
                    <div class="time">5 minutes ago</div>
                </div>
            </div>
        </div>

        <!-- Texto de boas-vindas -->
        <h1 class="welcome">Bem-vindo ao meu projeto Pipeline</h1>
    </div>

    <script>
        const source = document.getElementById('source');
        const build  = document.getElementById('build');
        const deploy = document.getElementById('deploy');
        const rebuildBtn = document.getElementById('rebuildBtn');

        function animatePipeline() {
            // Reset animation
            [source, build, deploy].forEach(card => {
                card.classList.remove('visible');
            });

            // Start animation sequence
            setTimeout(() => source.classList.add('visible'), 100);
            setTimeout(() => build.classList.add('visible'),  2600);
            setTimeout(() => deploy.classList.add('visible'), 5200);
        }

        // Primeiro carregamento
        window.onload = animatePipeline;

        // Clique no botão Rebuild
        rebuildBtn.addEventListener('click', () => {
            animatePipeline();
        });
    </script>
</body>
</html>

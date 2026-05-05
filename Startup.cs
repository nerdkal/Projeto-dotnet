using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MEUSITE
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração de serviços
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf-8";

                    var html = @"
<!DOCTYPE html>
<html lang='pt-BR'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Pipeline-Projeto</title>
    <script src='https://cdn.tailwindcss.com'></script>
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.6.0/css/all.min.css'>
    
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600&family=VT323&display=swap');

        body {
            font-family: 'Inter', 'Segoe UI', Arial, sans-serif;
            background: #0b1420;
            color: #e6edf3;
            min-height: 100vh;
            margin: 0;
            padding: 20px;
            overflow: hidden;
            position: relative;
        }

        canvas#matrix {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            z-index: -1;
            opacity: 0.15;
        }

        .pipeline-container {
            background: rgba(22, 27, 34, 0.95);
            border-radius: 16px;
            padding: 32px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.6);
            max-width: 1200px;
            width: 100%;
            margin: 0 auto;
            position: relative;
            z-index: 2;
        }

        /* Matrix Text */
        .matrix-text {
            font-family: 'VT323', monospace;
            font-size: 2.8rem;
            text-align: center;
            color: #00ff41;
            text-shadow: 
                0 0 10px #00ff41,
                0 0 20px #00ff41,
                0 0 40px #00ff41;
            margin: 30px 0 40px 0;
            letter-spacing: 4px;
            
        }

        @keyframes glitch {
            0% { text-shadow: 2px 2px #00ff41, -2px -2px #ff00ff; }
            20% { text-shadow: -2px -2px #00ff41, 2px 2px #ff00ff; }
            40% { text-shadow: 2px -2px #00ff41, -2px 2px #ffff00; }
            100% { text-shadow: 0 0 10px #00ff41; }
        }

        /* Restante dos estilos (mantidos iguais) */
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
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 4px;
            background: #2ea043;
            border-top-left-radius: 8px;
            border-top-right-radius: 8px;
        }

        .header { display: flex; align-items: center; gap: 8px; font-weight: 600; margin-bottom: 6px; }
        .check {
            width: 16px; height: 16px; background: #2ea043; border-radius: 50%; display: inline-block; position: relative;
        }
        .check::after {
            content: '✓'; position: absolute; color: #fff; font-size: 12px; top: 0; left: 4px;
        }

        .pipeline-id, .inner { background: #0d1117; border: 1px solid #30363d; }
        .pipeline-id { padding: 8px; border-radius: 4px; font-size: 12px; color: #58a6ff; margin-bottom: 6px; word-break: break-word; }
        .status { font-size: 13px; margin-bottom: 12px; color: #8b949e; }
        .inner { padding: 8px 12px; margin-bottom: 8px; font-size: 13px; border-radius: 6px; }

        .arrow {
            width: 60px; height: 3px; background: #2ea043; position: relative; top: 30px;
        }
        .arrow::after {
            content: ''; position: absolute; right: -10px; top: -6px;
            border-left: 12px solid #2ea043;
            border-top: 8px solid transparent;
            border-bottom: 8px solid transparent;
        }

        @keyframes fadeSlide {
            to { opacity: 1; transform: translateY(0); }
        }

        .top-header {
            display: flex; justify-content: space-between; align-items: center; margin-bottom: 35px;
        }

        h1.welcome {
            text-align: center;
            font-size: 2rem;
            color: #c9d1d9;
            margin-top: 20px;
        }
    </style>
</head>
<body>

    <canvas id='matrix'></canvas>

    <div class='pipeline-container'>
        <div class='top-header'>
            <div class='flex items-center gap-4'>
                <h1 class='text-3xl font-semibold'>Pipeline-Projeto</h1>
                <div class='flex items-center gap-2 text-emerald-400 text-sm'>
                    <span class='w-3 h-3 bg-emerald-400 rounded-full animate-pulse'></span>
                    Finished
                </div>
            </div>
            
            <div class='flex gap-3'>
                <button id='rebuildBtn' class='px-5 py-2 bg-gray-800 hover:bg-gray-700 rounded-xl text-sm flex items-center gap-2 transition'>
                    <i class='fas fa-redo'></i> Rebuild
                </button>
                <button class='px-6 py-2 bg-red-600 hover:bg-red-500 rounded-xl text-sm flex items-center gap-2 transition'>
                    <i class='fas fa-stop'></i> Stop Build
                </button>
            </div>
        </div>

        <div class='flex items-center justify-center gap-8'>
            <!-- Suas 3 caixas permanecem iguais -->
            <div id='source' class='stage-box'>
                <div class='header'><span class='check'></span><span>Source</span></div>
                <div class='pipeline-id'>Projeto 2</div>
                <div class='status'>All actions succeeded.</div>
                <div class='inner'>
                    <div class='label'><span class='check'></span> Source</div>
                    <div class='service'>GitHub (via GitHub App)</div>
                    <div class='time'>9 minutes ago</div>
                </div>
            </div>

            <div class='arrow'></div>

            <div id='build' class='stage-box'>
                <div class='header'><span class='check'></span><span>Build</span></div>
                <div class='pipeline-id'>Projeto 2</div>
                <div class='status'>All actions succeeded.</div>
                <div class='inner'>
                    <div class='label'><span class='check'></span> Build</div>
                    <div class='service'>AWS CodeBuild</div>
                    <div class='time'>8 minutes ago</div>
                </div>
            </div>

            <div class='arrow'></div>

            <div id='deploy' class='stage-box'>
                <div class='header'><span class='check'></span><span>Deploy</span></div>
                <div class='pipeline-id'>Projeto 2</div>
                <div class='status'>All actions succeeded.</div>
                <div class='inner'>
                    <div class='label'><span class='check'></span> Deploy</div>
                    <div class='service'>Amazon ECS</div>
                    <div class='time'>5 minutes ago</div>
                </div>
            </div>
        </div>

        <h1 class='matrix-text'>BEM-VINDO AO MEU PROJETO 2! MATRIX HAS FOUND YOU...</h1>
        
    </div>

    <script>
        // === MATRIX RAIN EFFECT ===
        const canvas = document.getElementById('matrix');
        const ctx = canvas.getContext('2d');

        canvas.height = window.innerHeight;
        canvas.width = window.innerWidth;

        const chars = '01アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワン0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ';
        const fontSize = 14;
        const columns = canvas.width / fontSize;
        const drops = [];

        for (let x = 0; x < columns; x++) drops[x] = Math.random() * canvas.height / fontSize;

        function drawMatrix() {
            ctx.fillStyle = 'rgba(11, 20, 32, 0.08)';
            ctx.fillRect(0, 0, canvas.width, canvas.height);
            
            ctx.fillStyle = '#00ff41';
            ctx.font = fontSize + 'px monospace';

            for (let i = 0; i < drops.length; i++) {
                const text = chars[Math.floor(Math.random() * chars.length)];
                ctx.fillText(text, i * fontSize, drops[i] * fontSize);

                if (drops[i] * fontSize > canvas.height && Math.random() > 0.975)
                    drops[i] = 0;

                drops[i]++;
            }
        }

        setInterval(drawMatrix, 35);

        window.addEventListener('resize', () => {
            canvas.height = window.innerHeight;
            canvas.width = window.innerWidth;
        });

        // === Animação das caixas (mantida) ===
        const source = document.getElementById('source');
        const build  = document.getElementById('build');
        const deploy = document.getElementById('deploy');
        const rebuildBtn = document.getElementById('rebuildBtn');

        function animatePipeline() {
            [source, build, deploy].forEach(card => card.classList.remove('visible'));
            setTimeout(() => source.classList.add('visible'), 100);
            setTimeout(() => build.classList.add('visible'),  2600);
            setTimeout(() => deploy.classList.add('visible'), 5200);
        }

        window.onload = animatePipeline;
        rebuildBtn.addEventListener('click', animatePipeline);
    </script>
</body>
</html>";

                    await context.Response.WriteAsync(html);
                });
            });
        }
    }
}

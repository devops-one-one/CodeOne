pipeline {
  agent any
  triggers {
    pollSCM("* * * * *")
  }
  environment {
    COMMITMSG = sh(returnStdout: true, script: "git log -1 --oneline")
  }
  stages{
    stage("Startup"){
      steps{
        buildDescription env.COMMITMSG
        dir("TestProject1"){
          sh "rm -rf TestResults"
        }
      }
    }
    stage("Build API"){
      steps{
        sh "dotnet build GymOneBackend/GymOneBackend.sln"
      }
    }

    stage("Build Frontend"){
          steps{
            dir('gym-one-fr') {
              sh "npm update"
              sh "ng build --prod"
              }
      }
      }

      stage("Test"){
        steps{
          dir("GymOneBackend/GymOneBackend.Core.Test"){
            sh "dotnet add package coverlet.collector"
            sh "dotnet test --collect:'Xplat Code Coverage'"
          }
        }
        post{
          success{
            archiveArtifacts "GymOneBackend/GymOneBackend.Core.Test/TestResults/*/coverage.cobertura.xml";
            publishCoverage adapters: [coberturaAdapter(path: "GymOneBackend/GymOneBackend.Core.Test/TestResults/*/coverage.cobertura.xml")] 
          }
           
         }
      }
      stage("Discord Webhook"){
        steps{
                discordSend description: 'Jenkins Pipeline Build', footer: 'Footer Text', link: env.BUILD_URL, result: currentBuild.currentResult, unstable: false, title: JOB_NAME, webhookURL: 'https://discord.com/api/webhooks/951841947276959745/0KkehKY4mDYFjXJKybgjDMfyAiIjsh0z8Iyklb77yGYpDxEShcnSaGjqpksiklnO16VZ'
        }
          }
          }
          }

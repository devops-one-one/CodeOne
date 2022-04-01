pipeline {
  agent any

    environment {
        DISCORD_WEBHOOK_URL = credentials('WEBHOOK_URL')
    }

  triggers {
    pollSCM("* * * * *")
  }

  stages{

      stage("Build API"){
      steps{
        dir("GymOneBackend"){
        sh "dotnet build --configuration Release"
        }
      }
    }

      stage("Build Frontend"){
          steps{
              dir("gym-one-fr") {
              sh "docker-compose build web"
              }
      }
      }

      stage("Unit Testing"){
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
                discordSend description: 'Team Vanilla', footer: 'You wish', image: 'https://i0.wp.com/www.imbored-letsgo.com/wp-content/uploads/2015/05/Classic-Creamy-Vanilla-Ice-Cream.jpg',link: env.BUILD_URL, result: currentBuild.currentResult, unstable: false, title: JOB_NAME, webhookURL: DISCORD_WEBHOOK_URL
        }
          }

      stage("Clean containers") {
            steps {
                script {
                    try {
                        sh "docker-compose down"
                    }
                    finally { }
                }
            }
        }

      stage("Deploy") {
          steps{
            sh "docker-compose up -d"
          }
          }
  }

}

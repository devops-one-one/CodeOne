pipeline {
  agent any

    environment {
        DISCORD_WEBHOOK_URL = credentials('WEBHOOK_URL')
    }

  triggers {
    pollSCM("H/5 * * * *")
  }

  stages{

    stage("Startup"){
      steps{
        dir("TestProject1"){
          echo"CLEAR TESTS"
          sh "rm -rf TestResults"
        }
      }
    }

      stage("Build Backend"){
          when {
                anyOf {
                    changeset "GymOneBackend/GymOneBackend.Core.Test/**"
                    changeset "GymOneBackend/GymOneBackend.Core/**"
                    changeset "GymOneBackend/GymOneBackend.Domain/**"
                    changeset "GymOneBackend/GymOneBackend.GymOneBackend.Repository/**"
                    changeset "GymOneBackend/GymOneBackend.GymOneBackend.Security/**"
                    changeset "GymOneBackend/GymOneBackend.GymOneBackend.WebAPI/**"
                }
          }
      steps{
        dir("GymOneBackend"){
        sh "dotnet build --configuration Release"
        }
        sh "docker-compose --env-file Config/Test.env build api"
      }
    }

      stage("Build Frontend"){
          when {
              changeset "gym-one-fr/**"
          }
          steps{
              dir("gym-one-fr") {
              sh "npm update"
              sh "ng build --prod"
              }
              sh "docker-compose --env-file Config/Test.env build web"
      }
      }

      stage("Unit Test"){
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

      stage("Clean containers") {
            steps {
                script {
                    try {
                        sh "docker-compose --env-file Config/Test.env down"
                    }
                    finally { }
                }
            }
        }

      stage("Deploy") {
          steps{
            sh "docker-compose --env-file Config/Test.env up -d"
          }
          }

      stage("Push to registry"){
        steps{
            sh "docker-compose --env-file Config/Test.env push"
          }
          }

      stage("Discord Webhook"){
          steps{
                discordSend description: 'Team Vanilla', footer: 'You wish', image: 'https://i0.wp.com/www.imbored-letsgo.com/wp-content/uploads/2015/05/Classic-Creamy-Vanilla-Ice-Cream.jpg',link: env.BUILD_URL, result: currentBuild.currentResult, unstable: false, title: JOB_NAME, webhookURL: DISCORD_WEBHOOK_URL
        }
          }
  }

}

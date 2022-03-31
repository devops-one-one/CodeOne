pipeline {
  agent any
  triggers {
    pollSCM("* * * * *")
  }
  environment {
    COMMITMSG = sh(returnStdout: true, script: "git log -1 --oneline")
  }
  stages{
    //stage("Startup"){
      //steps{
        //buildDescription env.COMMITMSG
        //dir("TestProject1"){
          //sh "rm -rf TestResults"
       // }
     // }
    //}

          stage("Clean containers") {
            steps {
                script {
                    try {
                        sh "docker rm -f frontend-app-container"
                    }
                    finally { }
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
                discordSend description: 'Team Vanilla', footer: 'You wish', image: 'https://i0.wp.com/www.imbored-letsgo.com/wp-content/uploads/2015/05/Classic-Creamy-Vanilla-Ice-Cream.jpg',link: env.BUILD_URL, result: currentBuild.currentResult, unstable: false, title: JOB_NAME, webhookURL: 'https://discord.com/api/webhooks/951841947276959745/0KkehKY4mDYFjXJKybgjDMfyAiIjsh0z8Iyklb77yGYpDxEShcnSaGjqpksiklnO16VZ'
        }
          }

        stage("Deploy") {
            parallel {
                stage("Deploy Frontend") {
                    steps {
                        dir("gym-one-fr") {
                            sh "docker build -t frontend-app ."
                            sh "docker run --name frontend-app-container -d -p 8090:80 frontend-app"
                        }
                    }
                }
          }
          }
  }
}

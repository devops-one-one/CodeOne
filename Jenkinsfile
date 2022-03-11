pipeline {
  agent any
  triggers {
    pollSCM("* * * * *")
  }
  environment {
    COMMITMSG = sh("git log -1 --oneline")
  }
  stages{
    stage("Startup"){
      steps{
        buildDescription env.COMMITMSG
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
              sh "ng build --prod"
              }
      }
      }
  }
}

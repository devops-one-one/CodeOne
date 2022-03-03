pipeline {
  agent any
  trigger {
    pollSCM("* * * * *")
  }
  stages{
    stage("OurFirstStage"){
      steps{
        echo "running"
      }
    }
  }
}
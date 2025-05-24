import subprocess
import os
import shutil

# Configuration
project_path = "."  # path to your .NET project or solution file
configuration = "Release"
output_base_dir = "publish_output"

# List of target runtimes (RIDs) to publish for
runtimes = ["win-x64", "linux-x64", "osx-x64"]

# Whether to publish self-contained (includes .NET runtime)
self_contained = True


def run_publish(runtime):
    print(f"Publishing for runtime: {runtime} (self-contained={self_contained})")

    # Build the dotnet publish command
    cmd = [
        "dotnet",
        "publish",
        project_path,
        "-c",
        configuration,
        "-r",
        runtime,
        "--output",
        os.path.join(output_base_dir, runtime),
    ]
    if self_contained:
        cmd.append("--self-contained")
    else:
        cmd.append("--no-self-contained")

    # Run the publish command
    result = subprocess.run(cmd, capture_output=True, text=True)
    if result.returncode != 0:
        print(f"Error publishing for {runtime}:\n{result.stderr}")
        return False
    else:
        print(f"Published successfully for {runtime}")
        return True


def clean_output():
    if os.path.exists(output_base_dir):
        print(f"Cleaning output directory: {output_base_dir}")
        shutil.rmtree(output_base_dir)
    os.makedirs(output_base_dir, exist_ok=True)


def main():
    clean_output()
    for rid in runtimes:
        success = run_publish(rid)
        if not success:
            print(f"Failed to publish for {rid}, stopping.")
            break
    print("Publishing process completed.")


if __name__ == "__main__":
    main()
